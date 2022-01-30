using System;
using Game.HealthSystem;
using Game.Ship;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCore : MonoBehaviour
    {
        public int dimensionID = 0;

        
        public ShipCore shipCore;
        public HealthCore healthCore;
        public PlayerCamera playerCamera;

        private void Start()
        {
            shipCore.playerCore = this;
        }

        public void SwapDimension()
        {
            if (dimensionID == 0)
            {
                dimensionID = 1;
                ChangeChildrenLayers(shipCore.gameObject, LayerMask.NameToLayer("Dimension2"));
            }
            else
            {
                dimensionID = 0;
                ChangeChildrenLayers(shipCore.gameObject, LayerMask.NameToLayer("Dimension1"));
            }
            
            
            playerCamera.SwapRender(dimensionID);
        }

        public void ChangeChildrenLayers(GameObject obj, int mask)
        {
            obj.layer = mask;

            foreach (Transform go in obj.transform)
            {
                ChangeChildrenLayers(go.gameObject, mask);
            }
            
        }
    }
}
