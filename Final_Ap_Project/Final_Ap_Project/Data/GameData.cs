namespace Final_Ap_Project.Data
{
    public static class GameData
    {
        public static int TotalCoins { get; set; } = 10000;
        public static int ExtraHP { get; set; } = 0;
        public static int ExtraSpeed { get; set; } = 0;
        public static int FireRateLevel { get; set; } = 0;
        public static int CurrentSkinIndex { get; set; } = 0;
        public static int HighScore { get; set; } = 0;

        public static int CurrentPlayerId;

        public static string CurrentUsername = "";

        public static bool[] UnlockedSkins { get; set; } = { true, false, false, false, false };
    }
}