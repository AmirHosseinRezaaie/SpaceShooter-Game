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
            CreateDefaultRow();
        }

        private static void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = @"
                CREATE TABLE IF NOT EXISTS PlayerData (
                    Id INTEGER PRIMARY KEY,
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

        private static void CreateDefaultRow()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM PlayerData";

                using (SQLiteCommand cmd = new SQLiteCommand(checkQuery, con))
                {
                    long count = (long)cmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string insert = @"
                        INSERT INTO PlayerData 
                        (Id, TotalCoins, HighScore, ExtraHP, ExtraSpeed, FireRateLevel, CurrentSkinIndex, UnlockedSkins)
                        VALUES
                        (1, 10000, 0, 0, 0, 0, 0, '1,0,0,0,0');
                        ";

                        using (SQLiteCommand insertCmd = new SQLiteCommand(insert, con))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void LoadGame()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM PlayerData WHERE Id = 1";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
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
                            if (i < parts.Length)
                                GameData.UnlockedSkins[i] = parts[i] == "1";
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
                UPDATE PlayerData
                SET
                    TotalCoins = @TotalCoins,
                    HighScore = @HighScore,
                    ExtraHP = @ExtraHP,
                    ExtraSpeed = @ExtraSpeed,
                    FireRateLevel = @FireRateLevel,
                    CurrentSkinIndex = @CurrentSkinIndex,
                    UnlockedSkins = @UnlockedSkins
                WHERE Id = 1";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TotalCoins", GameData.TotalCoins);
                    cmd.Parameters.AddWithValue("@HighScore", GameData.HighScore);
                    cmd.Parameters.AddWithValue("@ExtraHP", GameData.ExtraHP);
                    cmd.Parameters.AddWithValue("@ExtraSpeed", GameData.ExtraSpeed);
                    cmd.Parameters.AddWithValue("@FireRateLevel", GameData.FireRateLevel);
                    cmd.Parameters.AddWithValue("@CurrentSkinIndex", GameData.CurrentSkinIndex);
                    cmd.Parameters.AddWithValue("@UnlockedSkins", unlockedSkins);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}