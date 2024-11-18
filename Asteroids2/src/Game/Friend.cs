using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Asteroids2
{
    internal class Friend : Actor
    {
        private bool _isFound;
        private float _shootCooldown;
        private int _randomDecision;
        private float _timer;
        private float _speed;
        private float _turnSpeed;
        private float _lifespan;

        private float Lifespan 
        {
            get => _lifespan;

            set
            {
                _lifespan = value;

                if (_lifespan <= 0.0f)
                    Destroy(this);
            }    
        }

        private enum Decision
        {
            FORWARD = 1,
            FORWARD2 = 2,
            FORWARD3 = 3,
            TURNLEFT = 4,
            TURNRIGHT = 5,
        }

        public Friend()
        {
            _isFound = false;
            _speed = 200.0f;
            _turnSpeed = 150.0f;
            _lifespan = 30.0f;

            Collider = new CircleCollider(this, 20);
        }

        public override void Start()
        {
        LoopAround component = new LoopAround(this);
        AddComponent(component);
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);



            // if it is following the player
            if (_isFound)
            {
                // decrease the shoot cooldown if its more than 0
                if (_shootCooldown > 0.0f)
                    _shootCooldown -= (float)deltaTime;

                // friend can shoot
                if (Raylib.IsKeyDown(KeyboardKey.Space) && _shootCooldown <= 0.0f)
                {
                    Instantiate(new Bullet(), null, Transform.GlobalPosition, -Transform.GlobalRotationAngle);
                    _shootCooldown = 0.5f;
                }
            }
            // if not following the player
            else
            {
                // always move forward
                Transform.Translate(Transform.Forward * _speed * (float)deltaTime);

                // set the timer and decision if the timer is at 0
                if (_timer <= 0.0f)
                {
                    _randomDecision = RandomNumberGenerator.GetInt32(1, 6);

                    switch ((Decision)_randomDecision)
                    {
                        case Decision.FORWARD:
                            _timer = 3.0f;
                            break;
                        case Decision.FORWARD2:
                            _timer = 2.0f;
                            break;
                        case Decision.FORWARD3:
                            _timer = 1.0f;
                            break;
                        case Decision.TURNLEFT:
                            _timer = 0.33f;
                            break;
                        case Decision.TURNRIGHT:
                            _timer = 0.33f;
                            break;
                        default:
                            break;
                    }
                }
                // otherwise, turn if the random decision decided to turn and decrease the timer and lifespan
                else
                {
                    if (_randomDecision == 5)
                        Transform.Rotate(1.0f * ((float)Math.PI / 180) * -_turnSpeed * (float)deltaTime);
                    else if (_randomDecision == 6)
                        Transform.Rotate(-1.0f * ((float)Math.PI / 180) * -_turnSpeed * (float)deltaTime);

                    _timer -= (float)deltaTime;
                    Lifespan -= (float)deltaTime;
                }
            }


            // drwaing
            Raylib.DrawPoly(Transform.GlobalPosition, 3, 10, -Transform.GlobalRotationAngle * (180 / (float)Math.PI), Color.White);
        }

        public override void OnCollision(Actor other)
        {
            // if collided with player
            if (other is Player && !_isFound)
            {
                // and said player has less than 8 children, add the friend as a child of the player, set the local position to some weird math, set the rotaiton to 0, disable the looping component
                // aaaaaand set _isfound to true. and also remove the looping component cuz its attached to the player now
                if (other.Transform.Children.Length < 8)
                {
                    other.Transform.AddChild(Transform);

                    // this math makes the friends' positions alternate between halves of a circle-ish shape when they are collected
                    if (other.Transform.Children.Length % 2 == 1)
                    {
                        Transform.LocalPosition = new Vector2
                        ((float)Math.Sin(((other.Transform.Children.Length / 2) - 1) * .52f),
                        (float)Math.Cos(((other.Transform.Children.Length / 2) - 1) * .52f)).Normalized * 1.4f;
                    }
                    else
                    {
                        Transform.LocalPosition = new Vector2
                        ((float)Math.Sin(((other.Transform.Children.Length / 2) + 4) * -.52f),
                        (float)Math.Cos(((other.Transform.Children.Length / 2) + 4) * -.52f)).Normalized * 1.4f;
                    }


                    Transform.LocalRotation = Matrix3.CreateRotation(0);
                    RemoveComponent<LoopAround>();
                    _isFound = true;
                    Collider = null;
                }
                // otherwise, destroy this guy
                else
                {
                    Destroy(this);
                }



            }
        }
    }
}
