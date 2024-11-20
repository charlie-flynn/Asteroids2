using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
using System.Security.Cryptography;
using Asteroids2.src.Game;

namespace Asteroids2
{
    internal class GameScene : Scene
    {
        private double _spawnTimer;
        private double _score;
        private int _difficultyModifier;
        private int _lives;
        private bool _isBossSpawned;
        private Player _player;

        private bool AreThereAsteroids
        {
            get
            {
                foreach(Actor actor in Actors)
                {
                    if (actor is Asteroid)
                        return true;
                }
                return false;
            }
        }

        public GameScene()
        {
            _score = 0;
            _difficultyModifier = 0;
            _lives = 3;
            _spawnTimer = 0.0;
        }

        public override void Start()
        {
            base.Start();

            // add functions to the necessary delegates if theyre not already there
            Asteroid.onDeath = OnAsteroidKill;
            Player.onDeath = OnPlayerDeath;
            Friend.onCollectWithMaxFriends = OnFriendCollectWithMaxFriends;

            

            // create a player and a friend
            _player = (Player)Actor.Instantiate(new Player(), null, new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
            Actor.Instantiate(new Friend(), null, new Vector2(0, Raylib.GetScreenHeight() / 2));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // if the spawn timer is 0 or there are no asteroids left, spawn asteroids at the edge of the screen
            if (_spawnTimer <= 0.0 || !AreThereAsteroids)
            {

                SpawnStuff(5 + _difficultyModifier);

                if (_difficultyModifier >= 20 && !_isBossSpawned)
                {
                    Actor.Instantiate(new EvilRedSkull(_player), null, new Vector2(Raylib.GetScreenWidth() / 2, 0), 0);
                    _isBossSpawned = true;
                }


                _spawnTimer = 30.0;
            }

            // set the difficulty modifier and lower the spawn timer by deltaTime
            if (_difficultyModifier < 20)
            {
                _difficultyModifier = (int)_score / 100000;
            }

            _spawnTimer -= deltaTime;

            // print what little ui we need
            Raylib.DrawText(_score.ToString() + "\n\n" + _lives.ToString(), 10, 10, 40, Color.Red);
        }

        private void OnAsteroidKill(float radius)
        {
            // when asteroid is kil, give points based on its radius
            _score += (int)(radius * 100);
        }

        private void OnPlayerDeath()
        {
            // lower your lives, and if your lives are 0 or lower, move on to the score scene
            _lives--;
            if (_lives <= 0)
            {
                Game.CurrentScene = new ScoreScene(_score);
            }
        }

        private void OnFriendCollectWithMaxFriends()
        {
            // give the player a buncha points
            _score += 250000;
        }

        private void SpawnStuff(int amount)
        {
            // spawn all of the asteroids
            for (int i = 0; i <= amount; i++)
            {
                // generate random position and angle variance
                int rng = RandomNumberGenerator.GetInt32(1, 101);
                float angleVariance = RandomNumberGenerator.GetInt32(-45, 46) * ((float)Math.PI / 180);
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

                // decide whether or not to spawn a friend :)
                rng = RandomNumberGenerator.GetInt32(1, 16);
                if (rng == 1)
                {
                    Actor.Instantiate(new Friend(), null, randomPosition, spawnAngle);
                }
            }

        }
    }
}
