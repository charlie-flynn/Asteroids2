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

            // looping around the screen code
            if (Owner.Transform.GlobalPosition.x > Raylib.GetScreenWidth() + Owner.Transform.GlobalScale.Magnitude * 2)
                Owner.Transform.Translate(-Raylib.GetScreenWidth() - Owner.Transform.GlobalScale.Magnitude * 2, 0);

            if (Owner.Transform.GlobalPosition.x < 0 - Owner.Transform.GlobalScale.Magnitude * 2)
                Owner.Transform.Translate(Raylib.GetScreenWidth() + Owner.Transform.GlobalScale.Magnitude * 2, 0);

            if (Owner.Transform.GlobalPosition.y > Raylib.GetScreenHeight() + Owner.Transform.GlobalScale.Magnitude * 2)
                Owner.Transform.Translate(0, -Raylib.GetScreenHeight() - Owner.Transform.GlobalScale.Magnitude * 2);

            if (Owner.Transform.GlobalPosition.y < 0 - Owner.Transform.GlobalScale.Magnitude * 2)
                Owner.Transform.Translate(0, Raylib.GetScreenHeight() + Owner.Transform.GlobalScale.Magnitude * 2);
        }
    }
}
