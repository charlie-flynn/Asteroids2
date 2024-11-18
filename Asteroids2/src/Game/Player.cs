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
        public delegate void TOnDeath();
        public static TOnDeath onDeath;
        private float _momentum = 0;
        private float _acceleration = 10.0f;
        private float _decceleration = 12.0f;
        private float _turnSpeed = 200.0f;
        private Color _color = Color.White;
        private float _shootCooldown = 0.0f;
        private bool _isDead = false;
        private double _respawnTimer;
        private bool _isInvincible;
        private double _invincibleTimer;

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

            // if you are dead, reduce the respawn timer by deltatime, and if the respawntimer is done, respawn
            if (_isDead)
            {
                _respawnTimer -= deltaTime;
                if (_respawnTimer <= 0.0)
                {
                    Respawn();
                }    
            }

            // invincible co
            if (_isInvincible)
            {
                _color = Color.Red;
                _invincibleTimer -= deltaTime;
                if (_invincibleTimer <= 0.0)
                {
                    _isInvincible = false;
                    _color = Color.White;
                }
            }

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
            if (Raylib.IsKeyDown(KeyboardKey.Space) && _shootCooldown <= 0.0f)
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
            Color.Black);
        }

        public override void OnCollision(Actor other)
        {
            if (other is Asteroid && !_isInvincible && !_isDead)
                Die();
        }

        private void Die()
        {
            _isDead = true;
            Transform.LocalPosition = new Vector2(10000000, 10000000);
            _respawnTimer = 2.0;

            foreach (Transform2D child in Transform.Children)
            {
                Destroy(child.Owner);
            }
            onDeath();
        }

        private void Respawn()
        {
            _isDead = false;
            _isInvincible = true;
            _invincibleTimer = 3.0;
            Transform.LocalPosition = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            Transform.LocalRotation = Matrix3.Identity;
        }
    }
}
