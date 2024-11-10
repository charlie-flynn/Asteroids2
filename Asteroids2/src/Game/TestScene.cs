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
        Friend _friend;
        Friend _friend2;
        Friend _friend3;
        Friend _friend4;
        Friend _friend5;
        Friend _friend6;
        Friend _friend7;
        Friend _friend8;
        Friend _friend9;
        public override void Start()
        {
            base.Start();

            _player = (Player)Actor.Instantiate(new Player(), null, new Vector2(50, 50), 0);
            _player.Collider = new CircleCollider(_player, 5);

            _astaroid = (Asteroid)Actor.Instantiate(new Asteroid(60, 30), null, new Vector2(200, 200), 0);

            _friend2 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(120, 100), 0);
            _friend3 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(140, 100), 0);
            _friend4 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(160, 100), 0);
            _friend5 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(180, 100), 0);
            _friend6 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(200, 100), 0);
            _friend7 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(220, 100), 0);
            _friend8 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(240, 100), 0);
            _friend9 = (Friend)Actor.Instantiate(new Friend(), null, new Vector2(260, 100), 0);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            _player.Collider.Draw();
        }
    }
}
