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
    internal class Asteroid : Actor
    {
        private float _radius;
        private float _speed;
        private float _invulnTime;

        public Asteroid(float radius, float speed)
        {
            _radius = radius;
            _speed = speed;
            _invulnTime = 1.0f;
            Collider = new CircleCollider(this, _radius);
        }
        public override void Start()
        {
            AddComponent(new LoopAround(this));
            
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // reduce the invuln timer on spawning
            if (_invulnTime > 0.0f)
                _invulnTime -= (float)deltaTime;

            // move a wee bit
            Transform.Translate(Transform.Forward * _speed * (float)deltaTime);

            // check if a bullet has collided when not invulnerable
            if (_invulnTime <= 0.0f)
                if (Collider.CheckCollision<Bullet>())
                {
                    Destroy(this);
                    Destroy(Collider.CollidedActor);
                }


            Raylib.DrawCircleV(Transform.GlobalPosition, _radius, Color.Blue);
        }

        public override void End()
        {
            if (_radius >= 20.0f)
            {
                Instantiate(new Asteroid(_radius / 2, _speed * 1.2f), null, Transform.GlobalPosition + new Vector2(_radius, 0), -Transform.GlobalRotationAngle - 45);
                Instantiate(new Asteroid(_radius / 2, _speed * 1.2f), null, Transform.GlobalPosition + new Vector2(0, _radius), -Transform.GlobalRotationAngle + 45);
            }
            base.End();
        }
    }
}
