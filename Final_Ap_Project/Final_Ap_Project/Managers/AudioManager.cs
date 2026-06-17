using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace Final_Ap_Project.Managers
{
    public static class AudioManager
    {
        private static SoundPlayer coinSound;
        private static SoundPlayer explosionSound;
        private static SoundPlayer gameOverSound;
        private static SoundPlayer hitDamageSound;
        private static SoundPlayer successSound;
        private static SoundPlayer menuMusic;
        private static SoundPlayer backgroundMusic;

        public static bool SFXEnabled { get; set; } = true;
        public static bool MusicEnabled { get; set; } = true;

        public static void Init()
        {
            coinSound = new SoundPlayer(Properties.Resources.CoinSound);
            explosionSound = new SoundPlayer(Properties.Resources.ExposionSound);
            gameOverSound = new SoundPlayer(Properties.Resources.GameOverSound);
            hitDamageSound = new SoundPlayer(Properties.Resources.HitDamageSound);
            successSound = new SoundPlayer(Properties.Resources.SuccesSound);

            menuMusic = new SoundPlayer(Properties.Resources.MenuMusic);
            backgroundMusic = new SoundPlayer(Properties.Resources.BackgroundMusic);
        }

        // SFX Methods:
        public static void PlayCoin()
        {
            if (SFXEnabled) coinSound?.Play();
        }

        public static void PlayExplosion()
        {
            if (!SFXEnabled) return;

            using (SoundPlayer sp = new SoundPlayer(Properties.Resources.ExposionSound))
            {
                sp.Play();
            }
        }

        public static void PlayHit()
        {
            if (SFXEnabled) hitDamageSound?.Play();
        }

        public static void PlaySuccess()
        {
            if (SFXEnabled) successSound?.Play();
        }

        public static void PlayGameOver()
        {
            if (SFXEnabled) gameOverSound?.Play();
        }

        // Music:
        public static void PlayMenuMusic()
        {
            if (!MusicEnabled) return;
            menuMusic?.PlayLooping();
        }

        public static void PlayBackgroundMusic()
        {
            if (!MusicEnabled) return;
            if (backgroundMusic == null) return;
            backgroundMusic?.PlayLooping();
        }

        public static void StopMusic()
        {
            menuMusic?.Stop();
            backgroundMusic?.Stop();
        }
    }
}
