using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace Asteroids2
{
    internal class RainbowColor : Actor
    {
        private Color _rainbow = new Color(255, 0, 0, 255);
        private bool? _colorShift = true;

        public Color Rainbow { get => _rainbow; }

        public RainbowColor()
        {

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (_colorShift == true)
            {
                _rainbow.G++;
                _rainbow.R--;
                if (_rainbow.G == 255)
                    _colorShift = false;
            }
            else if (_colorShift == false)
            {
                _rainbow.B++;
                _rainbow.G--;
                if (_rainbow.B == 255)
                    _colorShift = null;
            }
            else
            {
                _rainbow.R++;
                _rainbow.B--;
                if (_rainbow.R == 255)
                    _colorShift = true;
            }
        }
    }
}
