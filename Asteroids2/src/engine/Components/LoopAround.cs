using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids2
{
    internal class LoopAround : Component
    {
        public LoopAround(Actor owner) : base(owner)
        {

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // if the actor is offscreen, move it to the opposite edge of the screen.
            if (Enabled)
            {
                if (Owner.Transform.GlobalPosition.x > Raylib.GetScreenWidth() + Owner.Transform.GlobalScale.x)
                    Owner.Transform.Translate(-Raylib.GetScreenWidth() - Owner.Transform.GlobalScale.Magnitude, 0);

                if (Owner.Transform.GlobalPosition.x < 0 - Owner.Transform.GlobalScale.x)
                    Owner.Transform.Translate(Raylib.GetScreenWidth() + Owner.Transform.GlobalScale.Magnitude, 0);

                if (Owner.Transform.GlobalPosition.y > Raylib.GetScreenHeight() + Owner.Transform.GlobalScale.y)
                    Owner.Transform.Translate(0, -Raylib.GetScreenHeight() - Owner.Transform.GlobalScale.Magnitude);

                if (Owner.Transform.GlobalPosition.y < 0 - Owner.Transform.GlobalScale.y)
                    Owner.Transform.Translate(0, Raylib.GetScreenHeight() + Owner.Transform.GlobalScale.Magnitude);
            }

        }
    }
}
