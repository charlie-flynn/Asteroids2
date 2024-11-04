using System;
using System.Collections.Generic;
using System.Linq;
using MathLibrary;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids2
{
    internal class Actor
    {
        private Transform2D _transform;
        private bool _started = false;
        private bool _enabled = true;

        public string Name { get; set; }
        public bool Started { get => _started; }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                // If enabled would not changed, do nothing
                if (_enabled == value) return;

                _enabled = value;
                // if value is true, call OnEnable
                if (_enabled)
                    OnEnable();
                // if value is false, call OnDisable
                else
                    OnDisable();
            }
        }

        public Collider Collider { get; set; }
        public Transform2D Transform { get; protected set; }

        public Actor(string name = "Actor")
        {
            Name = name;
            Start();
        }

        public static Actor Instantiate(
            Actor actor,
            Transform2D parent = null,
            Vector2 position = new Vector2(), 
            float rotation = 0,
            string name = "Actor")
        {


            // set actor's transform values
            actor.Transform.LocalPosition = position;
            actor.Transform.Rotate(rotation);
            actor.Name = name;
            if (parent != null)
                parent.AddChild(actor.Transform);



            // Add actor to current scene
            Game.CurrentScene.AddActor(actor);

            return actor;
        }

        public static void Destroy(Actor actor)
        {
            // remove children
            foreach (Transform2D child in actor.Transform.Children)
            {
                actor.Transform.RemoveChild(child);
            }

            // unchild from parent
            if (actor.Transform.Parent != null)
                actor.Transform.Parent.RemoveChild(actor.Transform);

            Game.CurrentScene.RemoveActor(actor);
        }

        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
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

        public virtual void OnCollision(Actor other)
        {

        }
    }
}
