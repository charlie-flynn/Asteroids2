using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

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

            Actor.Instantiate(new Player(), null, new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (_spawnTimer <= 0.0)
            {
                Actor.Instantiate(new Asteroid(50, 10), null, new Vector2(), 0);
                _spawnTimer = 20.0 - _difficultyModifier;

                if (_spawnTimer < 5)
                    _spawnTimer = 5;
            }

            _difficultyModifier = (int)_score / 5000;

            _spawnTimer -= deltaTime;

            Raylib.DrawText(_score.ToString(), 10, 10, 20, Color.Red);
        }
    }
}
