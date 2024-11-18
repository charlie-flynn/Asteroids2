using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
using System.IO;

namespace Asteroids2
{
    internal class TitleScreen : Scene
    {

        private Vector2 screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

        public TitleScreen()
        {

        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Raylib.DrawTextPro(new Font(), "Asteroids 2",
        new Vector2(screenDimensions.x / 2, 60), new Vector2(screenDimensions.x / 4, 0), 0, 80, 1, Color.Green);

            Raylib.DrawTextPro(new Font(), "Press Enter to Start",
        new Vector2(screenDimensions.x / 2, screenDimensions.y - screenDimensions.y / 6), new Vector2(screenDimensions.x / 4, 0), 0, 40, 1, Color.Green);

            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                Game.CurrentScene = new GameScene();

            if (Raylib.IsKeyDown(KeyboardKey.F3))
            {
                try
                {
                File.Delete(@"dat\scoreboard.dat");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

        }
    }
}
