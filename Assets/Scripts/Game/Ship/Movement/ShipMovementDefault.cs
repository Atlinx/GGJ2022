using UnityEngine;

namespace Game.Ship.Movement
{
    [CreateAssetMenu(menuName = "Ship Attachments/Movement/Default", fileName = "Ship Movement Default")]
    public class ShipMovementDefault : ShipMovementBase
    {
        public int Speed;
        public int RotSpeed;
        
        
        public override void UpdateMove(ShipCore core)
        {
            core.Rigidbody2D.velocity = core.InputValues.MovementDir * (Speed * core.shipConfig.SpeedMultiplier);
            
            var euler = core.transform.eulerAngles;
            
            core.transform.eulerAngles = new Vector3(euler.x, euler.y, Mathf.LerpAngle(euler.z, core.InputValues.AimRotation - 90, Time.deltaTime * RotSpeed));
        }
    }
}