using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace Asteroids2
{
    internal class CircleCollider : Collider
    {
        public float CollisionRadius { get; set; }

        public CircleCollider(Actor owner, float radius) : base(owner)
        {
            CollisionRadius = radius;
        }

        public override bool CheckCollisionCircle(CircleCollider collider)
        {
            float distance = Vector2.Distance(collider.Owner.Transform.GlobalPosition, Owner.Transform.GlobalPosition);
            float sumRadii = collider.CollisionRadius + CollisionRadius;

            if (sumRadii >= distance)
            {
                CollidedActor = collider.Owner;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLinesV(Owner.Transform.GlobalPosition, CollisionRadius, Color.Red);
        }
    }
}
