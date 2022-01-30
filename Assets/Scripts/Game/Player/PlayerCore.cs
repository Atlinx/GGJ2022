using Game.HealthSystem;
using Game.Ship;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCore : MonoBehaviour
    {
        public int dimensionID = 0;

        public LayerMask DimensionCollision1;
        public LayerMask DimensionCollision2;
        
        public ShipCore shipCore;
        public HealthCore healthCore;
        public PlayerCamera playerCamera;

        public void SwapDimension()
        {
            if (dimensionID == 0)
            {
                dimensionID = 1;
                shipCore.gameObject.layer = DimensionCollision2;
            }
            else
            {
                dimensionID = 0;
                shipCore.gameObject.layer = DimensionCollision1;
            }
            
            
            playerCamera.SwapRender(dimensionID);

        }
    }
}
