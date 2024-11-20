using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Asteroids2
{
    internal class EvilRedSkull : Actor
    {
        private float _speed;
        private Player _target;

        public EvilRedSkull(Player target)
        {
            _speed = 15.0f;
            _target = target;
        }

        public override void Start()
        {
            Collider = new CircleCollider(this, 50);
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            // calculate the direction and distance from the target, then move accordingly
            Vector2 directionToTarget = (Transform.GlobalPosition - _target.Transform.GlobalPosition).Normalized * -1;
            float distanceToTarget = Vector2.Distance(Transform.GlobalPosition, _target.Transform.GlobalPosition);

            Transform.Translate((directionToTarget * (_speed + (distanceToTarget))) * (float)deltaTime);

            // draw the evil red skull
            Raylib.DrawCircleV(Transform.GlobalPosition, 50, Color.Red);
            Raylib.DrawRectangleV(new Vector2(Transform.GlobalPosition.x - 30, Transform.GlobalPosition.y + 30), new Vector2(20, 30), Color.Red);
            Raylib.DrawRectangleV(new Vector2(Transform.GlobalPosition.x + 10, Transform.GlobalPosition.y + 30), new Vector2(20, 30), Color.Red);
            Raylib.DrawTriangle(
                new Vector2(Transform.GlobalPosition.x - 30, Transform.GlobalPosition.y - 30),
                new Vector2(Transform.GlobalPosition.x - 30, Transform.GlobalPosition.y + 10),
                new Vector2(Transform.GlobalPosition.x - 10, Transform.GlobalPosition.y + 10),
                Color.Black);
            Raylib.DrawTriangle(
                new Vector2(Transform.GlobalPosition.x + 10, Transform.GlobalPosition.y + 10),
                new Vector2(Transform.GlobalPosition.x + 30, Transform.GlobalPosition.y + 10),
                new Vector2(Transform.GlobalPosition.x + 30, Transform.GlobalPosition.y - 30),
                Color.Black);
        }
    }
}
