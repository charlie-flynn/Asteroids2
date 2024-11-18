using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.IO;
using MathLibrary;

namespace Asteroids2.src.Game
{
    internal class ScoreScene : Scene
    {
        private string _playerName = "";
        private double _playerScore;
        private double _nameTyped;
        private double _timer;
        private double[] _scoreboardScores = new double[5];
        private string[] _scoreboardNames = new string[5];
        private bool _isScoreNew;
        private bool _isScoreHigh;
        private int _screenProgress = 0;
        private Vector2 screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

        public ScoreScene(double score)
        {
            _playerScore = score;
        }

        public override void Start()
        {
            base.Start();

            // create the necessary files should they not exist
            if (!File.Exists(@"dat"))
                Directory.CreateDirectory(@"dat");
            if (!File.Exists(@"dat\scoreboard.dat"))
                File.WriteAllLines(@"dat\scoreboard.dat", new string[]
                {
                    "1000000",
                    "Plimby",
                    "500000",
                    "Skeebo",
                    "250000",
                    "Skop",
                    "100000",
                    "Peven",
                    "2",
                    "BAD@GAME"
                });



            using (StreamReader reader = new StreamReader(@"dat\scoreboard.dat"))
            {
                for (int i = 0; i < _scoreboardNames.Length; i++)
                {
                    _scoreboardScores[i] = double.Parse(reader.ReadLine());
                    _scoreboardNames[i] = reader.ReadLine();
                }
            }

            _isScoreNew = RegisterNewScore();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);


            Raylib.DrawTextPro(new Font(), "Your Score", new Vector2(screenDimensions.x / 2, 10), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
            Raylib.DrawTextPro(new Font(), _playerScore.ToString(), new Vector2(screenDimensions.x / 2, 40), new Vector2(screenDimensions.x / 10, 0), 0, 50, 1, Color.Green);

            if (_isScoreNew && _screenProgress == 0)
            {
                Raylib.DrawTextPro(new Font(), "Good Job!", new Vector2(screenDimensions.x / 2, 100), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
                Raylib.DrawTextPro(new Font(), "Enter Your Name", new Vector2(screenDimensions.x / 2, 130), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
                Raylib.DrawTextPro(new Font(), "> " + _playerName, new Vector2(screenDimensions.x / 2, 170), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);


                KeyboardKey keyPressed = (KeyboardKey)Raylib.GetKeyPressed();
                if (keyPressed != 0)
                {
                    if (_playerName.Length < 8)
                    {
                        if (keyPressed == KeyboardKey.Space)
                        {
                            _playerName += " ";
                        }

                        else if (keyPressed >= (KeyboardKey)65 && keyPressed <= (KeyboardKey)90)
                        {
                            if (keyPressed == KeyboardKey.R)
                                _playerName += "R";
                            else
                                _playerName += keyPressed.ToString();
                        }
                        else if (keyPressed >= (KeyboardKey)48 && keyPressed <= (KeyboardKey)57)
                        {
                            switch (keyPressed)
                            {
                                case KeyboardKey.One:
                                    _playerName += "1"; break;
                                case KeyboardKey.Two:
                                    _playerName += "2"; break;
                                case KeyboardKey.Three:
                                    _playerName += "3"; break;
                                case KeyboardKey.Four:
                                    _playerName += "4"; break;
                                case KeyboardKey.Five:
                                    _playerName += "5"; break;
                                case KeyboardKey.Six:
                                    _playerName += "6"; break;
                                case KeyboardKey.Seven:
                                    _playerName += "7"; break;
                                case KeyboardKey.Eight:
                                    _playerName += "8"; break;
                                case KeyboardKey.Nine:
                                    _playerName += "9"; break;
                                case KeyboardKey.Zero:
                                    _playerName += "0"; break;
                            }
                        }
                    }

                    if (keyPressed == KeyboardKey.Backspace && _playerName.Length != 0)
                    {
                        _playerName = _playerName.Remove(_playerName.Length - 1);
                    }
                }

            }
            else if (_screenProgress == 1)
            {

            }
            else if (_screenProgress == 0)
            {
                _screenProgress++;
            }

            


        }

        public override void End()
        {
            base.End();
        }

        private bool RegisterNewScore()
        {
            int j = _scoreboardScores.Length;
            foreach (double score in _scoreboardScores)
            {
                if (_playerScore > score)
                    j--;
            }

            if (j == _scoreboardScores.Length)
                return false;
            else
            {
                _scoreboardScores[j] = _playerScore;
                if (j == 0)
                    _isScoreHigh = true;
                return true;
            }    
        }
    }
}
