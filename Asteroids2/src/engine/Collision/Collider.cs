using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids2
{
    internal class Collider
    {
        public Actor Owner { get; protected set; }
        public Actor CollidedActor { get; protected set; }

        public Collider(Actor owner)
        {
            Owner = owner;
        }

        public bool CheckCollision(Actor other)
        {
            if (other.Collider != null && other.Collider is CircleCollider)
            {
                return CheckCollisionCircle((CircleCollider)other.Collider);
            }
                

            return false;
        }

        public bool CheckCollision<T>() where T : Actor
        {
            foreach (Actor actor in Game.CurrentScene.Actors)
            {
                if (actor is T && actor.Collider != null && actor.Collider is CircleCollider)
                    if (CheckCollisionCircle((CircleCollider)actor.Collider))
                    {
                        CollidedActor = actor;
                        return true;
                    }
            }

            return false;
        }

        public virtual bool CheckCollisionCircle(CircleCollider collider)
        {
            return false;
        }

        public virtual void Draw()
        {

        }
    }
}
