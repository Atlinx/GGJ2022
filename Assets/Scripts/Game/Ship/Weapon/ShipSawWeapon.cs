using UnityEngine;

namespace Game.Ship.Weapon
{
    public class ShipSawWeapon : ShipWeaponBase
    {

        public float lerpSpeedUpTime = 5f;
        public float speedMultiplier;
        public float sawRotationSpeed;

        private float targetSpeedMultiplier = 1;

        public override void UpdateWeapon(ShipCore core)
        {
            
            
            
            if (core.InputValues.isAttackHeld)
            {
                core.shipConfig.weaponGameObject.transform.Rotate(new Vector3(0,0,1), targetSpeedMultiplier * sawRotationSpeed * Time.deltaTime);
                targetSpeedMultiplier = speedMultiplier;
            }
            else
            {
                targetSpeedMultiplier = 1;
            }

            core.shipConfig.SpeedMultiplier = Mathf.Lerp(
                core.shipConfig.SpeedMultiplier, targetSpeedMultiplier, lerpSpeedUpTime * Time.deltaTime);
        }
    }
}