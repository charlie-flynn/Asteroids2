using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace Asteroids2
{
    internal class Asteroid : Actor
    {
        public delegate void TOnDeath(float radius);
        public delegate void TOnSpawn(Asteroid asteroid);
        public static TOnDeath onDeath;
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
            base.End();
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            if (other is Bullet)
            {
                Die();
                Destroy(other);
            }
        }

        private void Die()
        {
            // if the asteroid bigger than a certain size, create two asteroids 
            if (_radius > 20.0f)
            {
                Instantiate(new Asteroid(_radius / 2, _speed * 1.2f), null, Transform.GlobalPosition + new Vector2(_radius, 0), -Transform.GlobalRotationAngle - 45);
                Instantiate(new Asteroid(_radius / 2, _speed * 1.2f), null, Transform.GlobalPosition + new Vector2(0, _radius), -Transform.GlobalRotationAngle + 45);
            }
            onDeath(_radius);
            Destroy(this);
        }
    }
}
