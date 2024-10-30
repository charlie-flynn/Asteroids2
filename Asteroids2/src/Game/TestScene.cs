using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Asteroids2
{
    internal class TestScene : Scene
    {
        public override void Start()
        {
            base.Start();

            // Add iyr (new neopronoun i just made up) cool actor
            Actor actor = new TestActor();
            actor.Transform.LocalPosition = new Vector2(100, 100);
            AddActor(actor);
        }
    }
}
