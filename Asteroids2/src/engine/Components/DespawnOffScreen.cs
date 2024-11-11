using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids2
{
    internal class DespawnOffScreen : Component
    {
        public DespawnOffScreen(Actor owner) : base(owner)
        {

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // if the actor is offscreen, destroy it.
            if
                (
                Owner.Transform.GlobalPosition.x > Raylib.GetScreenWidth() + Owner.Transform.GlobalScale.x ||
                Owner.Transform.GlobalPosition.x < 0 - Owner.Transform.GlobalScale.x ||
                Owner.Transform.GlobalPosition.y > Raylib.GetScreenHeight() + Owner.Transform.GlobalScale.y ||
                Owner.Transform.GlobalPosition.y < 0 - Owner.Transform.GlobalScale.y
                )
                Actor.Destroy(Owner);



        }
    }
}
