using UnityEngine;

namespace Game.Ship.Abilities
{
    public abstract class ShipAbilityBase : ShipAttachmentBase
    {
        public abstract void Trigger(ShipCore core);

    }
}