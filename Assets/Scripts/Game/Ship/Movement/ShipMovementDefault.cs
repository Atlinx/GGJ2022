using UnityEngine;

namespace Game.Ship.Movement
{
    [CreateAssetMenu(menuName = "Ship Attachments/Movement/Default", fileName = "Ship Movement Default")]
    public class ShipMovementDefault : ShipMovementBase
    {

        public int Speed;
        
        public override void Update(ShipCore core)
        {
            core.Rigidbody2D.velocity = Speed * core.InputValues.MovementDir;
        }
    }
}