using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
using System.Security.Cryptography;

namespace Asteroids2
{
    internal class GameScene : Scene
    {
        private double _score = 0;
        private int _difficultyModifier = 0;
        private double _spawnTimer = 0.0;

        public override void Start()
        {
            base.Start();

            Asteroid.onDeath += OnAsteroidKill;

            Actor.Instantiate(new Player(), null, new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (_spawnTimer <= 0.0)
            {
                SpawnStuff(6);

                _spawnTimer = 5 - (_difficultyModifier * 2);

                if (_spawnTimer < 5.0)
                    _spawnTimer = 5.0;
            }

            _difficultyModifier = (int)_score / 50000;

            _spawnTimer -= deltaTime;

            Raylib.DrawText(_score.ToString(), 10, 10, 20, Color.Red);
        }

        private void OnAsteroidKill(float radius)
        {
            _score += (int)(radius * 100);
        }

        private void SpawnStuff(int amount)
        {
            // spawn all of the asteroids
            for (int i = 0; i < amount; i++)
            {
                int rng = RandomNumberGenerator.GetInt32(1, 101);
                Vector2 randomPosition;

                // decide which side to put the asteroid on
                if (rng < 25)
                {
                    randomPosition = new Vector2(0, Raylib.GetScreenHeight() / (rng / 4 + .0001f));
                }
                else if (rng < 50)
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight() / (rng / 4));
                }
                else if (rng < 75)
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth() / (rng / 4), 0);
                }
                else
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth() / (rng / 4), Raylib.GetScreenHeight());
                }

                Vector2 center = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
                Vector2 spawnToCenterDirection = (randomPosition - center).Normalized;

                // spawn the asteroid
                // TO DO: actually make it go towards the center kinda
                Actor.Instantiate(new Asteroid(50, 15), null, randomPosition, spawnToCenterDirection.Angle(new Vector2(1, 0)) * (180 / (float)Math.PI));

                rng = RandomNumberGenerator.GetInt32(1, 21);
                if (rng == 1)
                {
                    Actor.Instantiate(new Friend(), null, randomPosition, 0);
                }
            }

        }
    }
}
