using UnityEngine;

namespace Game.Ship.Weapon
{
    public abstract class ShipWeaponBase : ShipAttachmentBase
    {
        public abstract void UpdateWeapon(ShipCore core);
    }
}