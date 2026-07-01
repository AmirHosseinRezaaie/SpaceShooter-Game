using Final_Ap_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Ap_Project.Managers
{
    public class WaveManager
    {
        public int CurrentWave { get; private set; }
        public int TotalEnemiesInWave { get; private set; }
        public int SpawnedEnemies { get; private set; }
        public bool WaveCompleted { get; private set; }

        private int spawnTimer = 0;
        private int spawnInterval = 50;
        private Random rnd = new Random();
        private Player player;

        public WaveManager(Player player)
        {
            this.player = player;
            CurrentWave = 1;
        }

        private int GetEnemyCount(int wave)
        {
            return 3 + wave * 2;
        }

        public void StartWave()
        {
            TotalEnemiesInWave = GetEnemyCount(CurrentWave);
            SpawnedEnemies = 0;
            WaveCompleted = false;
            spawnTimer = 0;
        }

        public void Update(List<Enemy> enemies)
        {
            spawnTimer++;

            if (SpawnedEnemies < TotalEnemiesInWave)
            {
                if (spawnTimer >= spawnInterval)
                {
                    enemies.Add(CreateEnemy());

                    SpawnedEnemies++;

                    spawnTimer = 0;
                }
            }

            else
            {
                if (enemies.Count == 0)
                {
                    WaveCompleted = true;
                }
            }
        }

        private Enemy CreateEnemy()
        {
            int x = rnd.Next(60, 840);

            Enemy enemy;

            int chance = rnd.Next(100);

            if (CurrentWave <= 3)
            {
                if (chance < 70)
                    enemy = new StandardEnemy(x, -50, 2, Properties.Resources.EnemySpaceship);
                else
                    enemy = new ScoutEnemy(x, -50, 3, Properties.Resources.ScoutShip);
            }
            else if (CurrentWave <= 6)
            {
                if (chance < 50)
                    enemy = new StandardEnemy(x, -50, 2, Properties.Resources.EnemySpaceship);
                else if (chance < 75)
                    enemy = new ScoutEnemy(x, -50, 3, Properties.Resources.ScoutShip);
                else
                    enemy = new ShooterEnemy(x, -50, 2, Properties.Resources.ShooterSpaceship);
            }
            else if (CurrentWave <= 9)
            {
                if (chance < 30)
                    enemy = new StandardEnemy(x, -50, 2, Properties.Resources.EnemySpaceship);
                else if (chance < 55)
                    enemy = new ScoutEnemy(x, -50, 3, Properties.Resources.ScoutShip);
                else if (chance < 85)
                    enemy = new ShooterEnemy(x, -50, 2, Properties.Resources.ShooterSpaceship);
                else
                    enemy = new TerroristEnemy(x, -50, 2, Properties.Resources.TerroristShip, player);
            }
            else
            {
                if (chance < 20)
                    enemy = new StandardEnemy(x, -50, 2, Properties.Resources.EnemySpaceship);
                else if (chance < 40)
                    enemy = new ScoutEnemy(x, -50, 3, Properties.Resources.ScoutShip);
                else if (chance < 70)
                    enemy = new ShooterEnemy(x, -50, 2, Properties.Resources.ShooterSpaceship);
                else if (chance < 90)
                    enemy = new TerroristEnemy(x, -50, 2, Properties.Resources.TerroristShip, player);
                else
                    enemy = new HeavyTankEnemy(x, -50, 1, Properties.Resources.HeavyTank);
            }

            ApplyDifficulty(enemy);

            return enemy;
        }

        private void ApplyDifficulty(Enemy enemy)
        {
            enemy.Speed = (int)(enemy.Speed * (1 + 0.1 * CurrentWave));

            enemy.HP += 2 * CurrentWave;
        }

        public void NextWave()
        {
            CurrentWave++;

            StartWave();
        }
    }
}
