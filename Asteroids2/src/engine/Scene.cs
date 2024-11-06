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
        public List<Actor> Actors { get => _actors; }

        public void AddActor(Actor actor)
        {
            if (!_actors.Contains(actor))
                 _actors.Add(actor);
        }

        public bool RemoveActor(Actor actor)
        {
           return _actors.Remove(actor);
        }

        public virtual void Start()
        {
            _actors = new List<Actor>();
        }

        public virtual void Update(double deltaTime)
        {
            try
            {
                foreach (Actor actor in _actors)
                {
                    if (!actor.Started)
                        actor.Start();

                    actor.Update(deltaTime);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            

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
            try
            {
                foreach (Actor actor in _actors)
                {
                    actor.End();
                }
            }
            catch
            {

            }

        }

        
    }
}
