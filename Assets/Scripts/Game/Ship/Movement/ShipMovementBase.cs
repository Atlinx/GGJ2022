using UnityEngine;

namespace Game.Ship.Movement
{
    public abstract class ShipMovementBase : ShipAttachmentBase
    {
        public abstract void UpdateMove(ShipCore core);
    }
}
