using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Asteroids2.src.Game
{
    internal class ScoreScene : Scene
    {
        double playerScore;
        double timer;

        public ScoreScene(double score)
        {
            playerScore = score;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Raylib.DrawText(playerScore.ToString(), 100, 100, 20, Color.Pink);
        }
    }
}
