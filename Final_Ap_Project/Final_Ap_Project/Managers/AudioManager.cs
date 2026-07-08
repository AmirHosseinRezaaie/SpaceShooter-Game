using System;
using System.Media;
using NAudio.Wave;

namespace Final_Ap_Project.Managers
{
    public static class AudioManager
    {
        // Sound Effects
        private static SoundPlayer coinSound;
        private static SoundPlayer explosionSound;
        private static SoundPlayer gameOverSound;
        private static SoundPlayer hitDamageSound;
        private static SoundPlayer successSound;
        private static SoundPlayer scoreSound;
        private static SoundPlayer healthPackSound;

        // Menu Music
        private static SoundPlayer menuMusic;

        // Background Music (NAudio)
        private static WaveOutEvent backgroundMusicPlayer;
        private static WaveStream backgroundMusicStream;

        public static bool IsGameMusicPlaying { get; set; }

        public static bool SFXEnabled { get; set; } = true;
        public static bool MusicEnabled { get; set; } = true;

        public static void Init()
        {
            coinSound = new SoundPlayer(Properties.Resources.CoinSound);
            explosionSound = new SoundPlayer(Properties.Resources.ExposionSound);
            gameOverSound = new SoundPlayer(Properties.Resources.GameOverSound);
            hitDamageSound = new SoundPlayer(Properties.Resources.Damagewav);
            successSound = new SoundPlayer(Properties.Resources.SuccesSound);
            scoreSound = new SoundPlayer(Properties.Resources.ScoreSound);
            healthPackSound = new SoundPlayer(Properties.Resources.healthPackSound);

            menuMusic = new SoundPlayer(Properties.Resources.MenuMusic);
        }

        // SFX Methods:
        public static void PlayCoin()
        {
            if (SFXEnabled) coinSound?.Play();
        }

        public static void PlayExplosion()
        {
            if (SFXEnabled) explosionSound?.Play();
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
        public static void PlayScore()
        {
            if (SFXEnabled) scoreSound?.Play();
        }

        public static void PlayHealthPack()
        {
            if (SFXEnabled) healthPackSound?.Play();
        }


        // Music:
        public static void PlayMenuMusic()
        {
            if (!MusicEnabled)
                return;

            StopBackgroundMusic();
            menuMusic?.PlayLooping();

            IsGameMusicPlaying = false;
        }

        public static void PlayBackgroundMusic()
        {
            if (!MusicEnabled)
                return;

            menuMusic?.Stop();

            StopBackgroundMusic();

            WaveFileReader musicFile = new WaveFileReader(Properties.Resources.BackgroundMusic);

            backgroundMusicStream = new LoopStream(musicFile);

            backgroundMusicPlayer = new WaveOutEvent();

            backgroundMusicPlayer.Init(backgroundMusicStream);

            backgroundMusicPlayer.Play();

            IsGameMusicPlaying = true;
        }

        private static void StopBackgroundMusic()
        {
            backgroundMusicPlayer?.Stop();
            backgroundMusicPlayer?.Dispose();
            backgroundMusicPlayer = null;

            backgroundMusicStream?.Dispose();
            backgroundMusicStream = null;
        }

        public static void StopMusic()
        {
            menuMusic?.Stop();
            StopBackgroundMusic();
        }
    }
}