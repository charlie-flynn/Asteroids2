using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids2
{
    internal class Scene
    {
        private List<Actor> _actors;
        private List<Actor> _addedActors;
        private List<Actor> _removedActors;
        public List<Actor> Actors { get => _actors; }

        public void AddActor(Actor actor)
        {
            if (!_actors.Contains(actor))
                 _addedActors.Add(actor);
        }

        public bool RemoveActor(Actor actor)
        {
            if (_actors.Contains(actor))
            {
                _removedActors.Add(actor);
                return true;
            }
            return false;

        }

        public virtual void Start()
        {
            _actors = new List<Actor>();
            _addedActors = new List<Actor>();
            _removedActors = new List<Actor>();
        }

        public virtual void Update(double deltaTime)
        {
              foreach (Actor actor in _actors)
             {
                if (!actor.Started)
                    actor.Start();

                actor.Update(deltaTime);
             }

            foreach (Actor actor in _addedActors)
            {
                _actors.Add(actor);
            }
            
            foreach (Actor actor in _removedActors)
            {
                _actors.Remove(actor);
            }

            if (_addedActors.Count > 0)
                _addedActors.RemoveRange(0, _addedActors.Count);

            if (_removedActors.Count > 0)
                _removedActors.RemoveRange(0, _removedActors.Count);



            // check for collision
            for (int row = 0; row < _actors.Count; row++)
            {
                for (int column = row; column < _actors.Count; column++)
                {
                    if (row == column)
                        continue;

                    // if both colliders are valid, check collision
                    if (_actors[row].Collider != null && _actors[column].Collider != null)
                        if (_actors[row].Collider.CheckCollision(_actors[column]))
                        {
                            _actors[row].OnCollision(_actors[column]);
                            _actors[column].OnCollision(_actors[row]);
                        }

                }
            }
        }

        public virtual void End()
        {
                foreach (Actor actor in _actors)
                {
                    actor.End();
                }
        }

        
    }
}
