using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Asteroids2
{
    internal class Player : Actor
    {
        private float _momentum = 0;
        private float _acceleration = 0.2f;
        private float _decceleration = 0.06f;
        private float _turnSpeed = 150.0f;
        private Color _color = Color.Pink;

        public float Momentum 
        {
            get => _momentum;
            
            set
            {
                Math.Clamp(_momentum, 0.0f, 2.0f);
            }
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);


            // movement code
            if (Raylib.IsKeyDown(KeyboardKey.W))
                _momentum += _acceleration;
            else
                _momentum -= _decceleration;

            if (_momentum > 0)
                Transform.Translate(Transform.Forward * _momentum * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.D))
                Transform.Rotate((float)-((Raylib.IsKeyDown(KeyboardKey.A) - Raylib.IsKeyDown(KeyboardKey.D)) * (Math.PI / 180) * _turnSpeed * deltaTime));

            // looping around the screen code
            if (Transform.GlobalPosition.x > Raylib.GetScreenWidth() + Transform.GlobalScale.Magnitude)
                Transform.Translate(-Raylib.GetScreenWidth(), 0);

            if (Transform.GlobalPosition.x < 0 - Transform.GlobalScale.Magnitude)
                Transform.Translate(Raylib.GetScreenWidth(), 0);

            if (Transform.GlobalPosition.y > Raylib.GetScreenHeight() + Transform.GlobalScale.Magnitude)
                Transform.Translate(0, -Raylib.GetScreenHeight());

            if (Transform.GlobalPosition.y < 0 - Transform.GlobalScale.Magnitude)
                Transform.Translate(0, Raylib.GetScreenHeight());

            // drawing
            Raylib.DrawPoly(
            Transform.GlobalPosition,
            3,
            Transform.GlobalScale.x * 50,
            -Transform.GlobalRotationAngle * (180 / (float)Math.PI),
            Color.Pink);
            Vector2 offset = new Vector2(Transform.LocalScale.x * 40, Transform.LocalScale.y * 40);
            Raylib.DrawLineV(Transform.GlobalPosition,
            Transform.GlobalPosition + (Transform.Forward * Transform.LocalScale.x * 80),
            Color.SkyBlue);
        }

        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }
    }
}
