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
        private int _lives = 1;
        private double _spawnTimer = 0.0;
        public double Score { get => _score; }

        public GameScene()
        {
            _score = 0;
            _difficultyModifier = 0;
            _lives = 2;
            _spawnTimer = 0.0;
        }

        public override void Start()
        {
            base.Start();


            // add functions to the necessary delegates
            Asteroid.onDeath += OnAsteroidKill;
            Player.onDeath += OnPlayerDeath;
            Friend.onCollectWithMaxFriends += OnFriendCollectWithMaxFriends;

            // create a player
            Actor.Instantiate(new Player(), null, new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (_spawnTimer <= 0.0)
            {
                SpawnStuff(5 + _difficultyModifier);

                _spawnTimer = 25 - (_difficultyModifier * 2);

                if (_spawnTimer < 5.0)
                    _spawnTimer = 5.0;
            }

            _difficultyModifier = (int)_score / 250000;

            _spawnTimer -= deltaTime;

            Raylib.DrawText(_score.ToString() + "\n\n" + _lives.ToString(), 10, 10, 40, Color.Red);
        }

        private void OnAsteroidKill(float radius)
        {
            _score += (int)(radius * 100);
        }

        private void OnPlayerDeath()
        {
            _lives--;
            if (_lives <= 0)
            {
                Game.CurrentScene = new ScoreScene(_score);
            }
        }

        private void OnFriendCollectWithMaxFriends()
        {
            _score += 500000;
        }

        private void SpawnStuff(int amount)
        {
            // spawn all of the asteroids
            for (int i = 0; i < amount; i++)
            {
                // generate random position and angle variance
                int rng = RandomNumberGenerator.GetInt32(1, 101);
                float angleVariance = RandomNumberGenerator.GetInt32(-45, 46) * ((float)Math.PI / 180);

                // declare the position and angle
                Vector2 randomPosition;
                float spawnAngle;

                // decide where to place the asteroid based on the rng
                if (rng <= 25)
                {
                    randomPosition = new Vector2(0, Raylib.GetScreenHeight() / (((rng + .0001f) % 25) / 4));
                }
                else if (rng <= 50)
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight() / (((rng + .0001f) % 25) / 4));
                }
                else if (rng <= 75)
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth() / (((rng + .0001f) % 25) / 4), 0);
                }
                else
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth() / (((rng + .0001f) % 25) / 4), Raylib.GetScreenHeight());
                }
                if (rng % 25 == 0)
                {
                    randomPosition = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight() / 2);
                }
                Vector2 center = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
                Vector2 spawnToCenterDirection = (randomPosition - center).Normalized;

                // if the asteroid is higher up on the screen than the center, set the spawnAngle equal to that angle which happens to work
                // otherwise, set it equal to that other angle which works when its below the center
                if (randomPosition.y < center.y)
                    spawnAngle = Vector2.Angle(new Vector2(1, 0), spawnToCenterDirection * -1);
                else
                    spawnAngle = Vector2.Angle(new Vector2(1, 0), spawnToCenterDirection) + (float)Math.PI;

                // spawn the asteroid, using the randomPosition as the position and the sum of spawnAngle and angleVariance
                Actor.Instantiate(new Asteroid(50, 15), null, randomPosition, spawnAngle + angleVariance);

                rng = RandomNumberGenerator.GetInt32(1, 21);
                if (rng == 1)
                {
                    Actor.Instantiate(new Friend(), null, randomPosition, spawnAngle);
                }
            }

        }
    }
}
