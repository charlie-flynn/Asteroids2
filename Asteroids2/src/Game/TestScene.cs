using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Asteroids2
{
    internal class TestScene : Scene
    {
        Actor _gabooey;
        public override void Start()
        {
            base.Start();

            // Add iyr (new neopronoun i just made up) cool actor
            Actor actor = new TestActor();
            actor.Transform.LocalPosition = new Vector2(100, 100);
            AddActor(actor);
            actor.Collider = new CircleCollider(actor, 50);


            _gabooey = Actor.Instantiate(new Actor("Gabooey"), null, new Vector2(400, 400), 0, "Gabooey");
            _gabooey.Collider = new CircleCollider(_gabooey, 100);
            AddActor(_gabooey);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircleV(_gabooey.Transform.GlobalPosition, _gabooey.Transform.GlobalScale.x * 100, Color.Green);
        }
    }
}
