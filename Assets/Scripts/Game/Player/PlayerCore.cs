using System;
using Game.Dimensions;
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

        public LayerMask dimension1CollisionMask;
        public LayerMask dimension2CollisionMask;

        public GameObject InvertDimensionLayer;
        
        [HideInInspector] public int dimension1;
        [HideInInspector] public int dimension2;

        private void Awake()
        {
            dimension1 = LayerMask.NameToLayer("Dimension1");
            dimension2 = LayerMask.NameToLayer("Dimension2");
        }

        private void Start()
        {
            shipCore.playerCore = this;
            
            SetDimension(dimensionID);
        }

        public void SwapDimension()
        {
            if (dimensionID == 0)
            {
                dimensionID = 1;
            }
            else
            {
                dimensionID = 0;
            }

            SetDimension(dimensionID);
        }

        public void SetDimension(int id)
        {
            dimensionID = id;
            
            if (dimensionID == 0)
            {
                ChangeChildrenLayers(shipCore.gameObject, dimension1);
                ChangeChildrenLayers(InvertDimensionLayer, dimension2);
            }
            else
            {
                ChangeChildrenLayers(shipCore.gameObject, dimension2);
                ChangeChildrenLayers(InvertDimensionLayer, dimension1);
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

        public int GetDimensionLayer()
        {
            return dimensionID == 0 ? dimension1 : dimension2;
        }

        public LayerMask GetCollisionLayerMask()
        {
            return dimensionID == 0 ? dimension1CollisionMask : dimension2CollisionMask;
        }

        public void KillPlayer()
        {
            Debug.Log("Player Died");
            healthCore.ResetHealth();

            this.transform.position = DimensionCore._instance.GetRandomRespawnPoint();
        }
    }
}
