using Game.Player;
using UnityEngine;

namespace Game.Ship.Weapon
{
    [CreateAssetMenu(menuName = "Ship Attachments/Weapons/Saw")]
    public class ShipSawWeapon : ShipWeaponBase
    {

        public AnimationCurve speedRampUp;
        public float speedRampUpTime = 5f;
        public float speedMultiplier = 5f;
        public float sawRotationSpeed;
        public float attackMoveSpeed;

        public float damageCooldown;
        public int damageAmount;

        private float currentDamageCooldown;
        private float currentSpeedRampUpTime = 0;
        private float lastAimRotation;
        private bool lastAttackHeld;
        
        public override void UpdateWeapon(ShipCore core)
        {
            
            
            
            if (core.InputValues.isAttackHeld)
            {
                if (lastAttackHeld != core.InputValues.isAttackHeld)
                {
                    core.OnWeaponStart?.Invoke();
                }
                
                core.shipConfig.DisableMovement = true;
                core.shipConfig.weaponGameObject.transform.Rotate(new Vector3(0,0,1),  core.shipConfig.SpeedMultiplier * sawRotationSpeed * Time.deltaTime);

                core.transform.eulerAngles = new Vector3(0,0, lastAimRotation);
                core.Rigidbody2D.velocity = (core.transform.transform.up * core.shipConfig.SpeedMultiplier * attackMoveSpeed);
                currentSpeedRampUpTime += Time.deltaTime;


                currentDamageCooldown -= Time.deltaTime;
                
                
                core.OnWeaponFire?.Invoke();;

                if (currentDamageCooldown <= 0)
                {
                    foreach (var triggered in core.shipConfig.meleeTriggerContainer.currentlyHeld)
                    {
                        var playerCore = triggered.GetComponent<PlayerCore>();
                        if (playerCore == null) continue;

                        playerCore.healthCore.Damage(damageAmount);
                    }

                    currentDamageCooldown = damageAmount;
                }

            }
            else
            {
                if (lastAttackHeld != core.InputValues.isAttackHeld)
                {
                    core.OnWeaponEnd?.Invoke();
                }
                core.shipConfig.DisableMovement = false;
                lastAimRotation = core.InputValues.AimRotation - 90;
                currentDamageCooldown = damageCooldown;
                currentSpeedRampUpTime = 0;
            }
            
            lastAttackHeld = core.InputValues.isAttackHeld;

            currentSpeedRampUpTime = Mathf.Clamp(currentSpeedRampUpTime, 0, speedRampUpTime);

            core.shipConfig.SpeedMultiplier = (speedRampUp.Evaluate(currentSpeedRampUpTime / speedRampUpTime) * speedMultiplier) + 1;
        }
    }
}