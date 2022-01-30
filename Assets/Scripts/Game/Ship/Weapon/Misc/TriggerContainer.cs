using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ship.Weapon.Misc
{
    public class TriggerContainer : MonoBehaviour
    {
        public List<GameObject> currentlyHeld = new List<GameObject>();
        
        
        //BAD FAST CODE~!
        private void OnTriggerEnter2D(Collider2D other)
        {
            currentlyHeld.Remove(other.gameObject);
            currentlyHeld.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            currentlyHeld.Remove(other.gameObject);
        }
    }
}