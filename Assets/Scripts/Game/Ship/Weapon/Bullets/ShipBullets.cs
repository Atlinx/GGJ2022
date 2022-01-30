using System.Collections.Generic;
using Game.ObjectPooling;
using UnityEngine;

namespace Game.Ship.Weapon.Bullets
{
    public class ShipBullets : MonoBehaviour
    {
        public Vector3 velocity;
        public float speed;
        public float aliveTime;
        public ContactFilter2D filter;
        public ObjectPool objectPool;
        
        private Vector3 _lastPosition;

        public void Init(ObjectPool pool, Vector3 startPosition, Vector3 dir)
        {
            objectPool = pool;
            this.transform.position = startPosition;
        }
        
        public void Update()
        {
            Vector3 lineDif = _lastPosition - this.transform.position;
            CheckCollisions(this.transform.position, lineDif);
            
            _lastPosition = this.transform.position;

            this.transform.position = this.transform.position + (velocity * speed * Time.deltaTime);

        }

        private void CheckCollisions(Vector3 pos, Vector3 ray)
        {
            List<RaycastHit2D> results = new List<RaycastHit2D>();
            Physics2D.Raycast(pos, ray, filter, results, ray.magnitude);
            
            
            if(results.Count > 0)
            {
                RaycastHit2D closest = results[0];

                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].distance < closest.distance)
                    {
                        closest = results[i];
                    }
                }
                
                Collided(closest);
            }
        }

        private void Collided(RaycastHit2D obj)
        {
            objectPool.Push(this.gameObject);
        }
    }
}