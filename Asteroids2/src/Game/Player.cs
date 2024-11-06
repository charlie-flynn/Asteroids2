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
        private float _acceleration = 0.3f;
        private float _decceleration = 0.4f;
        private float _turnSpeed = 150.0f;
        private Color _color = Color.Pink;

        public float Momentum 
        {
            get => _momentum;
            
            set
            {
                _momentum = Math.Clamp((float)value, 0.0f, 750.0f);
            }
        }

        public override void Start()
        {
            base.Start();
            Transform.LocalScale = new Vector2(30, 30);
            AddComponent(new LoopAround(this));
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);


            // movement code
            if (Raylib.IsKeyDown(KeyboardKey.W))
                Momentum += _acceleration;
            else
                Momentum -= _decceleration;

            if (Momentum > 0.0f)
                Transform.Translate(Transform.Forward * Momentum * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.D))
                Transform.Rotate((float)-((Raylib.IsKeyDown(KeyboardKey.A) - Raylib.IsKeyDown(KeyboardKey.D)) * (Math.PI / 180) * _turnSpeed * deltaTime));



            // shooting code
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                Instantiate(new Bullet(), null, Transform.GlobalPosition, -Transform.GlobalRotationAngle, "Bullet");
            }

            // drawing
            Raylib.DrawPoly
            (Transform.GlobalPosition,
            3,
            Transform.GlobalScale.x,
            -Transform.GlobalRotationAngle * (180 / (float)Math.PI),
            Color.Pink);

            Vector2 offset = new Vector2(Transform.LocalScale.x, Transform.LocalScale.y);

            Raylib.DrawLineV
            (Transform.GlobalPosition,
            Transform.GlobalPosition + (Transform.Forward * Transform.LocalScale.x),
            Color.SkyBlue);

            Raylib.DrawText(Momentum.ToString(), 10, 10, 10, Color.Purple);
        }

        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }
    }
}
