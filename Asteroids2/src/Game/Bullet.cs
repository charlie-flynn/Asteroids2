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

        private float _speed = 0.1f;

        public override void Start()
        {
            base.Start();
            Transform.LocalScale = new Vector2(10, 30);
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Transform.Translate(Transform.Forward * _speed);

            Rectangle rec = new Rectangle(Transform.GlobalPosition, Transform.GlobalScale);
            Vector2 offset = new Vector2(Transform.GlobalPosition.x / 2, Transform.GlobalPosition.y / 2);

            Raylib.DrawRectanglePro(rec, new Vector2(5, 15), Transform.LocalRotationAngle * (180 / (float)Math.PI) + 90, Color.Red);
        }


    }
}
