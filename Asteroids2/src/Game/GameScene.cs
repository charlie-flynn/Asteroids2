using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
using static System.Formats.Asn1.AsnWriter;

namespace Asteroids2
{
    internal class GameScene : Scene
    {
        private double _score = 0;
        private double _timer = 0.0;

        public override void Start()
        {
            base.Start();

            Actor.Instantiate(new Player(), null, new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (_timer <= 0.0)
            {
                Actor.Instantiate(new Asteroid(50, 10), null, new Vector2());
                _timer = 60.0;
            }

            Raylib.DrawText(_score.ToString(), 10, 10, 20, Color.Red);
        }

        private void OnAsteroidKill(float radius)
        {
            _score += (radius * 100);
        }
    }
}
