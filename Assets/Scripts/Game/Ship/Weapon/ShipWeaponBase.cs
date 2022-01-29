using UnityEngine;

namespace Game.Ship.Weapon
{
    public abstract class ShipWeaponBase : ShipAttachmentBase
    {

        private bool onAttackStart = false;
        private bool onAttackStop = false;
        private bool _lastAttack;
        
        public virtual void Update()
        {
            onAttackStart = false;
            onAttackStop = false;
            
            if (_lastAttack != _shipCoreInstance.InputValues.DoAttack)
            {
                if (_lastAttack)
                {
                    onAttackStart = true;
                }
                else
                {
                    onAttackStop = true;
                }
            }

            _lastAttack = _shipCoreInstance.InputValues.DoAttack;
        }
    }
}