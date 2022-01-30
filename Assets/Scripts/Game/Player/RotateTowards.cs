using System;
using UnityEngine;

namespace Game.Player
{
    public class RotateTowards : MonoBehaviour
    {
        public SpriteRenderer srenderer;
        public GameObject target;
        public float hideDistance;
        private void Update()
        {
            Vector3 dir = target.transform.position - this.transform.position;

            srenderer.enabled = dir.magnitude > hideDistance;
            
            float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);

            this.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        }
    }
}
