using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.IO;
using MathLibrary;

namespace Asteroids2
{
    internal class ScoreScene : Scene
    {
        private string _playerName = "";
        private double _playerScore;
        private double[] _scoreboardScores = new double[10];
        private string[] _scoreboardNames = new string[10];
        private bool _isScoreNew;
        private bool _isScoreHigh;
        private int _scorePlace;
        private int _screenProgress = 0;
        private bool _errorOccured;
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
                    "10000000",
                    "PLIMBY",
                    "5000000",
                    "DINGLE",
                    "2500000",
                    "QUARM",
                    "1000000",
                    "SHLARP",
                    "500000",
                    "SKEEBO",
                    "250000",
                    "SKOP",
                    "100000",
                    "PEVEN",
                    "5000",
                    "MID",
                    "2",
                    "BAD@GAME",
                    "1",
                    "WORSE"
                });


            // deserialize the scoreboard
            using (StreamReader reader = new StreamReader(@"dat\scoreboard.dat"))
            {
                for (int i = 0; i < _scoreboardNames.Length; i++)
                {
                    try
                    {
                        _scoreboardScores[i] = double.Parse(reader.ReadLine());
                        _scoreboardNames[i] = reader.ReadLine();
                    }
                    catch (Exception e)
                    {
                        _errorOccured = true;
                        Console.WriteLine(e);
                    }
                }
            }

            // compare the score the player got to the scores on the scoreboard
            _isScoreNew = RegisterNewScore();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // always display the player's score
            Raylib.DrawTextPro(new Font(), "Your Score", new Vector2(screenDimensions.x / 2, 10), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
            Raylib.DrawTextPro(new Font(), _playerScore.ToString(), new Vector2(screenDimensions.x / 2, 40), new Vector2(screenDimensions.x / 10, 0), 0, 50, 1, Color.Green);

            if (_isScoreNew && _screenProgress == 0)
            {
                EnterNameScreen();
            }
            else if (_screenProgress == 1)
            {
                ScoreboardScreen();
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
            _scorePlace = _scoreboardScores.Length - 1;
            foreach (double score in _scoreboardScores)
            {
                if (_playerScore > score)
                    _scorePlace--;
            }

            if (_scorePlace == _scoreboardScores.Length - 1)
                return false;
            else
            {
                if (_scorePlace == 0)
                    _isScoreHigh = true;
                return true;
            }
        }

        private void EnterNameScreen()
        {
            // if the score is the highest score, display a joyous message :)
            if (_isScoreHigh)
            {
                Raylib.DrawTextPro(new Font(), "New High Score!", new Vector2(screenDimensions.x / 2, 100), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
            }
            else
            {
                Raylib.DrawTextPro(new Font(), "Good Job!", new Vector2(screenDimensions.x / 2, 100), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
            }

            // prompt the player to enter their name
            Raylib.DrawTextPro(new Font(), "Enter Your Name", new Vector2(screenDimensions.x / 2, 130), new Vector2(screenDimensions.x / 6, 0), 0, 30, 1, Color.Green);
            Raylib.DrawTextPro(new Font(), "> " + _playerName, new Vector2(screenDimensions.x / 2, 170), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);

            // if the player pressed a key and it can be typed in, type it into the player name
            // if they pressed backspace, remove the front-most character in the player name
            // if the player pressed enter, proceed to the scoreboard
            KeyboardKey keyPressed = (KeyboardKey)Raylib.GetKeyPressed();
            if (keyPressed != 0)
            {
                if (_playerName.Length < 10)
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

                if (keyPressed == KeyboardKey.Enter && _playerName != "")
                {
                    _screenProgress = 1;
                    _scoreboardNames[_scorePlace] = _playerName;
                    _scoreboardScores[_scorePlace] = _playerScore;
                    SerializeScoreboard();
                }
            }
        }

        private void ScoreboardScreen()
        {
            int yOffset = 120;

            // draw all of the scores on the scoreboard
            if (!_errorOccured)
            {
                for (int i = 0; i < _scoreboardScores.Length; i++)
                {
                    Raylib.DrawTextPro(new Font(), "#" + (i + 1) + ": " + _scoreboardScores[i],
                        new Vector2(screenDimensions.x / 2 - screenDimensions.x / 3, yOffset), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);
                    Raylib.DrawTextPro(new Font(), _scoreboardNames[i],
                        new Vector2(screenDimensions.x / 2 + screenDimensions.x / 3, yOffset), new Vector2(screenDimensions.x / 10, 0), 0, 30, 1, Color.Green);

                    yOffset += 30;
                }
            }
            else
            {
                Raylib.DrawTextPro(new Font(), "Scoreboard Error. \n\nPress F3 on the title screen to clear the scoreboard",
                    new Vector2(screenDimensions.x / 2 + screenDimensions.x / 3, yOffset), new Vector2(screenDimensions.x / 1.2f, 0), 0, 30, 1, Color.Red);
            }

            Raylib.DrawTextPro(new Font(), "Press Enter to return to title",
             new Vector2(screenDimensions.x / 2, screenDimensions.y - screenDimensions.y / 8), new Vector2(screenDimensions.x / 4, 0), 0, 30, 1, Color.Green);

            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                Game.CurrentScene = new TitleScene();
        }

        private void SerializeScoreboard()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"dat\scoreboard.dat"))
                {
                    for (int i = 0; i < _scoreboardScores.Length; i++)
                    {
                        writer.WriteLine(_scoreboardScores[i]);
                        writer.WriteLine(_scoreboardNames[i]);
                    }
                }
            }
            catch (Exception e)
            {
                _errorOccured = true;
                Console.WriteLine(e);
            }


        }
    }
}
