﻿using System;
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
        private Vector2 lastAsteroidSpawnDirection;

        public override void Start()
        {
            base.Start();

            Asteroid.onDeath += OnAsteroidKill;
            Player.onDeath += OnPlayerDeath;

            Actor.Instantiate(new Player(), null, new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (_spawnTimer <= 0.0)
            {
                SpawnStuff(1);

                _spawnTimer = 5 - (_difficultyModifier * 2);

                if (_spawnTimer < 5.0)
                    _spawnTimer = 5.0;
            }

            _difficultyModifier = (int)_score / 50000;

            _spawnTimer -= deltaTime;

            Raylib.DrawText(_score.ToString(), 10, 10, 20, Color.Red);

            if (lastAsteroidSpawnDirection != null)
                Raylib.DrawLineV(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2), new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2) + lastAsteroidSpawnDirection * 50, Color.Blue);
                Raylib.DrawLineV(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2), new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2) + new Vector2(1, 0) * 50, Color.Blue);
        }

        private void OnAsteroidKill(float radius)
        {
            _score += (int)(radius * 100);
        }

        private void OnPlayerDeath()
        {

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

                lastAsteroidSpawnDirection = spawnToCenterDirection;

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
