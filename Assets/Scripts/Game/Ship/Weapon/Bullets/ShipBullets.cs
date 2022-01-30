using System.Collections.Generic;
using Game.ObjectPooling;
using UnityEngine;

namespace Game.Ship.Weapon.Bullets
{
    public class ShipBullets : MonoBehaviour
    {
        public float speed;
        public int damage;
        public float aliveTime;
        public ContactFilter2D filter;
        public ObjectPool objectPool;

        public GameObject ignoreGameObject;
        
        private Vector3 _lastPosition;
        private float currentAlive;
        
        public void Init(ObjectPool pool, Vector3 startPosition, Vector3 dir)
        {
            objectPool = pool;
            this.transform.position = startPosition;
            currentAlive = 0;
            _lastPosition = this.transform.position;
        }
        
        public void Update()
        {
            Vector3 lineDif = _lastPosition - this.transform.position;
            CheckCollisions(this.transform.position, lineDif);
            
            _lastPosition = this.transform.position;

            this.transform.position = this.transform.position + (this.transform.up * speed * Time.deltaTime);
            currentAlive += Time.deltaTime;

            if (currentAlive > aliveTime)
            {
                OnFinished();
            }
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
                    if (results[i].collider.attachedRigidbody.gameObject == ignoreGameObject)
                    {
                        continue;
                    }
                    
                    if (results[i].distance < closest.distance)
                    {
                        closest = results[i];
                    }
                }

                if (closest.collider.attachedRigidbody.gameObject != ignoreGameObject)
                {
                    Collided(closest);
                }
            }
        }

        private void Collided(RaycastHit2D obj)
        {

            var colliderRG = obj.collider.attachedRigidbody;

            if (colliderRG != null)
            {
                var shipCore = colliderRG.gameObject.GetComponent<ShipCore>();

                if (shipCore != null)
                {
                    shipCore.playerCore.healthCore.Damage(damage);
                }
            }

            OnFinished();
        }

        private void OnFinished()
        {
            if (objectPool == null)
            {
                Destroy(this.gameObject);
                return;
            }
            objectPool.Push(this.gameObject);
        }
    }
}