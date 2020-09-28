using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity
{
    public class GameObject
    {
        public GameObject gameObject;
        private List<object> _components = new List<object>();

        public virtual void Update(){}
        public GameObject(){
            gameObject = this;
        }

        public GameObject(GameObject parent){
            gameObject = parent;
        }

        public T GetComponent<T>() where T : class
        {
            //check if multiple. if multiple, raise error?
            var component = _components.Where(c => c is T).FirstOrDefault();

            if (component != null){
                return (T)Convert.ChangeType(component,  typeof(T));
            }

            return null;
        }

        public void AddComponent<T>() where T : GameObject
        {
            _components.Add(Activator.CreateInstance(typeof(T), this));
        }
    }
}