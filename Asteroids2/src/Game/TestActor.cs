using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Asteroids2
{
    internal class TestActor : Actor
    {
        public float Speed { get; set; } = 150;
        private Color _color = Color.Pink;
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Vector2 movementInput = new Vector2(Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A),
                Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W));
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.Translate(deltaMovement);

            Raylib.DrawCircleV(Transform.GlobalPosition, 50, _color);
        }

        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }
    }
}
