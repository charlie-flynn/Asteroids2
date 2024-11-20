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
    internal class TitleScene : Scene
    {

        private Vector2 _screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        private byte _scoreboardWipeProgress;
        private RainbowColor _rainbow;

        public TitleScene()
        {

        }

        public override void Start()
        {
            base.Start();
            _rainbow = (RainbowColor)Actor.Instantiate(new RainbowColor());
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // message to appear when the player wants to wipe the scoreboard
            switch (_scoreboardWipeProgress)
            {
                case 1:
                    Raylib.DrawTextPro(new Font(), "Are you sure you want to clear the scoreboard?\n\nPress F3 again to confirm.",
                new Vector2(_screenDimensions.x / 2, _screenDimensions.y / 2), new Vector2(_screenDimensions.x / 4, 0), 0, 20, 1, Color.Red);
                    break;
                case 2:
                    Raylib.DrawTextPro(new Font(), "Scoreboard wiped.",
                new Vector2(_screenDimensions.x / 2, _screenDimensions.y / 2), new Vector2(_screenDimensions.x / 4, 0), 0, 20, 1, Color.Red);
                    break;
                default:
                    break;
            }


            Raylib.DrawTextPro(new Font(), "Asteroids 2",
        new Vector2(_screenDimensions.x / 2, 60), new Vector2(_screenDimensions.x / 4, 0), 0, 80, 1, _rainbow.Rainbow);

            Raylib.DrawTextPro(new Font(), "Press Enter to Start",
        new Vector2(_screenDimensions.x / 2, _screenDimensions.y - _screenDimensions.y / 6), new Vector2(_screenDimensions.x / 4, 0), 0, 40, 1, Color.Green);

            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                Game.CurrentScene = new GameScene();

            // delete the scoreboard if the player presses f3 twice
            if (Raylib.IsKeyPressed(KeyboardKey.F3))
            {
                if (_scoreboardWipeProgress < 2)
                {
                    _scoreboardWipeProgress++;

                    if (_scoreboardWipeProgress != 2)
                        return;
                }

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
