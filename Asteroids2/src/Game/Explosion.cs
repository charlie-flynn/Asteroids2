using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace Asteroids2
{
    internal class Explosion : Actor
    {
        private double _radius = 30;
        private float _dissipationSpeed = 40.0f;

        public override void Start()
        {
            base.Start();


        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            _radius -= _dissipationSpeed * deltaTime;

            Transform.LocalScale = new Vector2((float)_radius, (float)_radius);

            Raylib.DrawCircleV(Transform.GlobalPosition, Transform.GlobalScale.x, Color.Orange);

            if (_radius <= 0.0)
                Destroy(this);
        }
    }
}
