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


        public Asteroid(float radius, float speed)
        {
            _radius = radius;
            _speed = speed;
            Collider = new CircleCollider(this, _radius);
            Transform.LocalScale += new Vector2(_radius, _radius);
        }



        public override void Start()
        {
            AddComponent(new LoopAround(this));
            
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // move a wee bit
            Transform.Translate(Transform.Forward * _speed * (float)deltaTime);

            // draw
            Raylib.DrawCircleV(Transform.GlobalPosition, _radius, Color.Blue);
        }

        public override void End()
        {
            // if its bigger than a certain size, create two asteroids 
            if (_radius > 25.0f)
            {
                Instantiate(new Asteroid(_radius / 2, _speed * 1.2f), null, Transform.GlobalPosition + new Vector2(_radius, 0), -Transform.GlobalRotationAngle - 45);
                Instantiate(new Asteroid(_radius / 2, _speed * 1.2f), null, Transform.GlobalPosition + new Vector2(0, _radius), -Transform.GlobalRotationAngle + 45);
            }

            
            
            base.End();
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            if (other is Bullet)
            {
                Destroy(this);
                Destroy(other);
            }
        }
    }
}
