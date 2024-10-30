using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids2
{
    internal class Actor
    {
        private Transform2D _transform;
        private bool _started = false;

        public bool Started { get => _started; }
        public Transform2D Transform { get; set; }

        public Actor()
        {
            Start();
        }
        public virtual void Start()
        {
            _started = true;
            Transform = new Transform2D(this);
        }

        public virtual void Update(double deltaTime)
        {

        }

        public virtual void End()
        {

        }
    }
}
