using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Asteroids2
{
    internal class Bullet : Actor
    {

        private float _speed = 200.0f;

        public override void Start()
        {
            base.Start();
            Transform.LocalScale = new Vector2(10, 30);
            AddComponent(new DespawnOffScreen(this));
            Collider = new CircleCollider(this, 5);
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // move the bullet forward
            Transform.Translate(Transform.Forward * _speed * (float)deltaTime);

            // draw the bullet
            Raylib.DrawCircleV(Transform.GlobalPosition, 5, Color.Red);
        }


    }
}
