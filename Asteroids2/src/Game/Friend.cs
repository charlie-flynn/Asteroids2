using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Asteroids2
{
    internal class Friend : Actor
    {
        private bool _isFound;
        private LoopAround _component;
        private float _shootCooldown;

        public Friend()
        {
            _isFound = false;
            _component = new LoopAround(this);
            AddComponent(_component);
            Collider = new CircleCollider(this, 10);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // decrease the shoot cooldown if its more than 0
            if (_shootCooldown > 0.0f)
                _shootCooldown -= (float)deltaTime;

            // if it is following the player
            if (_isFound)
            {
                // friend can shoot
                if (Raylib.IsKeyPressed(KeyboardKey.Space) && _shootCooldown <= 0.0f)
                {
                    Instantiate(new Bullet(), null, Transform.GlobalPosition, -Transform.GlobalRotationAngle, "Bullet");
                    _shootCooldown = 0.5f;
                }
            }


            // drwaing
            Raylib.DrawPoly(Transform.GlobalPosition, 3, 10, -Transform.GlobalRotationAngle * (180 / (float)Math.PI), Color.Pink);
            Collider.Draw();
        }

        public override void OnCollision(Actor other)
        {
            // if collided with player
            if (other is Player && !_isFound)
            {
                // and said player has less than 9 children, add the friend as a child of the player, set the local position to some weird math, set the rotaiton to 0, disable the looping component
                // aaaaaand set isfound to true
                if (other.Transform.Children.Length < 9)
                {
                    other.Transform.AddChild(Transform);

                    if (other.Transform.Children.Length % 2 == 1)
                    {
                        Transform.LocalPosition = new Vector2
                        ((float)Math.Sin(((other.Transform.Children.Length / 2) - 1) * .52f),
                        (float)Math.Cos(((other.Transform.Children.Length / 2) - 1) * .52f)).Normalized * 1.2f;
                    }
                    else
                    {
                        Transform.LocalPosition = new Vector2
                        ((float)Math.Sin(((other.Transform.Children.Length / 2) + 4) * -.52f),
                        (float)Math.Cos(((other.Transform.Children.Length / 2) + 4) * -.52f)).Normalized * 1.2f;
                    }


                    Transform.LocalRotation = Matrix3.CreateRotation(0);
                    _component.Enabled = false;
                    _isFound = true;
                }
                else
                {
                    Destroy(this);
                }



            }
        }
    }
}
