using UnityEngine;
namespace Game.Ship.Movement
{
    [CreateAssetMenu(menuName = "Ship Attachments/Movement/Space", fileName = "Ship Movement Space")]
    public class ShipMovementSpace : ShipMovementBase
    {
        public float acceleration;
        public float turnAssitance;
        public int RotSpeed;

        public float MaxSpeed;
    
        public override void UpdateMove(ShipCore core)
        {
            var vel = core.Rigidbody2D.velocity;

            float mag = vel.magnitude;

            if (mag > MaxSpeed)
            {
                vel /= mag;
                vel *= MaxSpeed;
            }

            
            Vector2 different = (vel.normalized) - core.InputValues.MovementDir.normalized;

            
            
            core.Rigidbody2D.velocity = vel + (different.magnitude * turnAssitance * core.InputValues.MovementDir) +
                                        (core.InputValues.MovementDir * acceleration * Time.deltaTime);
            
            vel = core.Rigidbody2D.velocity;
            mag = vel.magnitude;

            if (mag > MaxSpeed)
            {
                vel /= mag;
                vel *= MaxSpeed;
            }

            core.Rigidbody2D.velocity = vel;
            
            var euler = core.transform.eulerAngles;
        
            core.transform.eulerAngles = new Vector3(euler.x, euler.y, Mathf.LerpAngle(euler.z, core.InputValues.AimRotation - 90, Time.deltaTime * RotSpeed));
        }
        
    }
}