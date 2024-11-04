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
        Player _player;
        public override void Start()
        {
            base.Start();

            _player = (Player)Actor.Instantiate(new Player(), null, new Vector2(50, 50), 0, "Player");
            AddActor(_player);




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
