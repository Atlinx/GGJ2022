using Game.Ship.Weapon.Bullets;
using UnityEngine;

namespace Game.Ship.Weapon
{
    [CreateAssetMenu(menuName = "Ship Attachments/Weapons/Gunner")]
    public class ShipGunnerWeapon : ShipWeaponBase
    {
        public float shootingSpeed;
        public float bulletSpeed;
        
        public float aliveTime;
        public int damage;

        public GameObject bulletPrefab;

        public float explosiveImpact;
        public override void UpdateWeapon(ShipCore core)
        {
            if (core.InputValues.isAttackHeld)
            {
                if (core.tempValues.weaponCooldown <= 0)
                {
                    Shoot(core);
                    core.tempValues.weaponCooldown = shootingSpeed;
                }
                core.tempValues.weaponCooldown -= Time.deltaTime;
            }
            else
            {
                core.tempValues.weaponCooldown = 0;
            }
        }

        public void Shoot(ShipCore core)
        {
            var spawnGunLocations = core.shipConfig.spawnGunLocations;
            core.OnWeaponFire?.Invoke();;
            for (int i = 0; i < spawnGunLocations.Length; i++)
            {
                var bulletObject = Instantiate(bulletPrefab);

                ShipBullets bullet = bulletObject.GetComponent<ShipBullets>();
                bullet.explosiveImpact = explosiveImpact;
                bullet.filter.layerMask = core.playerCore.GetCollisionLayerMask();
                bullet.gameObject.layer = core.playerCore.GetDimensionLayer();
                bullet.speed = bulletSpeed;
                bullet.damage = damage;
                bullet.aliveTime = aliveTime;
                bullet.ignoreGameObject = core.gameObject;
                
                bullet.transform.position = spawnGunLocations[i].transform.position;
                bullet.transform.rotation = core.transform.rotation;
                
                
            }

        }
    }
}
