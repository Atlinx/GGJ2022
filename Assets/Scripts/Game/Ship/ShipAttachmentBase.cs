using UnityEngine;

namespace Game.Ship
{
    public abstract class ShipAttachmentBase : ScriptableObject
    {
        protected ShipCore _shipCoreInstance;
        
        public void Init(ShipCore core)
        {
            _shipCoreInstance = core;
        }
    }
}