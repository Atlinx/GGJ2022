using UnityEngine;

namespace Game.Ship.Abilities
{
    public abstract class ShipAbilityBase : ShipAttachmentBase
    {
        public bool Pressed;

        public virtual void Start(ShipCore core) { }
        public virtual void Update(ShipCore core) { }
        public virtual void Stop(ShipCore core) { }
    }
}