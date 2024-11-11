﻿using Raylib_cs;
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
        private float _acceleration = 10.0f;
        private float _decceleration = 12.0f;
        private float _turnSpeed = 200.0f;
        private Color _color = Color.Pink;
        private float _shootCooldown = 0.0f;

        public float Momentum 
        {
            get => _momentum;
            
            set
            {
                _momentum = Math.Clamp((float)value, 0.0f, 300.0f);
            }
        }

        public override void Start()
        {
            base.Start();
            Transform.LocalScale = new Vector2(30, 30);
            Collider = new CircleCollider(this, 5);
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


            if (_shootCooldown > 0.0f)
                _shootCooldown -= (float)deltaTime;

            // shooting code
            if (Raylib.IsKeyPressed(KeyboardKey.Space) && _shootCooldown <= 0.0f)
            {
                Instantiate(new Bullet(), null, Transform.GlobalPosition, -Transform.GlobalRotationAngle);
                _shootCooldown = 0.5f;
            }

            // drawing
            Raylib.DrawPoly
            (Transform.GlobalPosition,
            3,
            Transform.GlobalScale.x,
            -Transform.GlobalRotationAngle * (180 / (float)Math.PI),
            _color);

            Vector2 offset = new Vector2(Transform.LocalScale.x, Transform.LocalScale.y);

            Raylib.DrawLineV
            (Transform.GlobalPosition,
            Transform.GlobalPosition + (Transform.Forward * Transform.LocalScale.x),
            Color.SkyBlue);
        }

        public override void OnCollision(Actor other)
        {
            if (other is Asteroid)
                _color = Color.Red;
        }
    }
}
