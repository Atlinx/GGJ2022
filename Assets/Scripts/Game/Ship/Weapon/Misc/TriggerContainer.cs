using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Weapon.Misc
{
    public class TriggerContainer : MonoBehaviour
    {
        public List<GameObject> currentlyHeld = new List<GameObject>();

        public List<GameObject> newObjectsBuffer = new List<GameObject>();
        
        //BAD FAST CODE~!
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody == null) return;
            
            var go = other.attachedRigidbody.gameObject;
            currentlyHeld.Remove(go);
            currentlyHeld.Add(go);

            newObjectsBuffer.Remove(go);
            newObjectsBuffer.Add(go);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.attachedRigidbody == null) return;
            try
            {
                currentlyHeld.Remove(other.attachedRigidbody.gameObject);
            }
            catch (NullReferenceException)
            {
                
            }
        }
    }
}