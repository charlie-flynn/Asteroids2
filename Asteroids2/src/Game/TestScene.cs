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
        Player _player;
        Asteroid _astaroid;
        public override void Start()
        {
            base.Start();

            _player = (Player)Actor.Instantiate(new Player(), null, new Vector2(50, 50), 0, "Player");
            _player.Collider = new CircleCollider(_player, 5);
            AddActor(_player);

            _astaroid = (Asteroid)Actor.Instantiate(new Asteroid(60, 30), null, new Vector2(200, 200), 0);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Raylib.DrawText(Actors.Count.ToString(), 10, 10, 30, Color.Purple);

            _player.Collider.Draw();
        }
    }
}
