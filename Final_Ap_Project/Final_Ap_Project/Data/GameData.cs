namespace Final_Ap_Project.Data
{
    public static class GameData
    {
        public static int TotalCoins { get; set; } = 0;
        public static int ExtraHP { get; set; } = 0;
        public static int ExtraSpeed { get; set; } = 0;
        public static int FireRateLevel { get; set; } = 0;
        // ایندکس 0: پیش‌فرض | 1: قرمز | 2: آبی | 3: سبز | 4: ویژه طلایی
        public static int CurrentSkinIndex { get; set; } = 0;

        public static bool[] UnlockedSkins { get; set; } = { true, false, false, false, false };
    }
}