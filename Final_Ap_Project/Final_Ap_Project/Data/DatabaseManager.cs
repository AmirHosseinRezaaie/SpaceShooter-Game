using System;
using System.Data.SQLite;
using System.IO;
using Final_Ap_Project.Data;

namespace Final_Ap_Project.Managers
{
    public static class DatabaseManager
    {
        private static readonly string dbPath = "game.db";
        private static readonly string connectionString = $"Data Source={dbPath};Version=3;";

        public static void Initialize()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            CreateTable();
        }

        private static void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = @"
                CREATE TABLE IF NOT EXISTS Players
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    Username TEXT UNIQUE,

                    Password TEXT,

                    TotalCoins INTEGER,

                    HighScore INTEGER,

                    ExtraHP INTEGER,

                    ExtraSpeed INTEGER,

                    FireRateLevel INTEGER,

                    CurrentSkinIndex INTEGER,

                    UnlockedSkins TEXT
                );";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void LoadGame()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Players WHERE Id = @Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", GameData.CurrentPlayerId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GameData.TotalCoins = Convert.ToInt32(reader["TotalCoins"]);
                            GameData.HighScore = Convert.ToInt32(reader["HighScore"]);
                            GameData.ExtraHP = Convert.ToInt32(reader["ExtraHP"]);
                            GameData.ExtraSpeed = Convert.ToInt32(reader["ExtraSpeed"]);
                            GameData.FireRateLevel = Convert.ToInt32(reader["FireRateLevel"]);
                            GameData.CurrentSkinIndex = Convert.ToInt32(reader["CurrentSkinIndex"]);

                            string skins = reader["UnlockedSkins"].ToString();

                            string[] parts = skins.Split(',');

                            for (int i = 0; i < GameData.UnlockedSkins.Length; i++)
                            {
                                GameData.UnlockedSkins[i] = false;

                                if (i < parts.Length)
                                    GameData.UnlockedSkins[i] = parts[i] == "1";
                            }
                        }
                    }
                }
            }
        }

        public static void SaveGame()
        {
            string unlockedSkins = "";

            for (int i = 0; i < GameData.UnlockedSkins.Length; i++)
            {
                if (GameData.UnlockedSkins[i])
                    unlockedSkins += "1";
                else
                    unlockedSkins += "0";

                if (i < GameData.UnlockedSkins.Length - 1)
                    unlockedSkins += ",";
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = @"
                UPDATE Players
                SET
                    TotalCoins = @TotalCoins,
                    HighScore = @HighScore,
                    ExtraHP = @ExtraHP,
                    ExtraSpeed = @ExtraSpeed,
                    FireRateLevel = @FireRateLevel,
                    CurrentSkinIndex = @CurrentSkinIndex,
                    UnlockedSkins = @UnlockedSkins
                WHERE Id = @Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TotalCoins", GameData.TotalCoins);
                    cmd.Parameters.AddWithValue("@HighScore", GameData.HighScore);
                    cmd.Parameters.AddWithValue("@ExtraHP", GameData.ExtraHP);
                    cmd.Parameters.AddWithValue("@ExtraSpeed", GameData.ExtraSpeed);
                    cmd.Parameters.AddWithValue("@FireRateLevel", GameData.FireRateLevel);
                    cmd.Parameters.AddWithValue("@CurrentSkinIndex", GameData.CurrentSkinIndex);
                    cmd.Parameters.AddWithValue("@UnlockedSkins", unlockedSkins);
                    cmd.Parameters.AddWithValue("@Id", GameData.CurrentPlayerId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static LoginResult LoginOrRegister(string username, string password)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query =
                    "SELECT * FROM Players WHERE Username = @Username";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string savedPassword =
                                reader["Password"].ToString();

                            if (savedPassword != password)
                            {
                                return LoginResult.WrongPassword;
                            }

                            GameData.CurrentPlayerId =
                                Convert.ToInt32(reader["Id"]);

                            GameData.CurrentUsername =
                                username;

                            return LoginResult.Success;
                        }
                    }
                }

                string insert = @"
                INSERT INTO Players
                (
                    Username,
                    Password,
                    TotalCoins,
                    HighScore,
                    ExtraHP,
                    ExtraSpeed,
                    FireRateLevel,
                    CurrentSkinIndex,
                    UnlockedSkins
                )
                VALUES
                (
                    @Username,
                    @Password,
                    100,
                    0,
                    0,
                    0,
                    0,
                    0,
                    '1,0,0,0,0'
                )";

                using (SQLiteCommand cmd = new SQLiteCommand(insert, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.ExecuteNonQuery();
                }

                string getId =
                    "SELECT Id FROM Players WHERE Username = @Username";

                using (SQLiteCommand cmd = new SQLiteCommand(getId, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    GameData.CurrentPlayerId =
                        Convert.ToInt32(cmd.ExecuteScalar());

                    GameData.CurrentUsername =
                        username;
                }

                return LoginResult.NewAccountCreated;
            }
        }
    }
}