using System;
using Game.Ship.Abilities;
using Game.Ship.Movement;
using Game.Ship.Weapon;
using UnityEngine;

namespace Game.Ship
{
    public class ShipCore : MonoBehaviour
    {
        public struct ShipInputValues
        {
            public Vector2 MovementDir;
            public float MovementRotation;

            public bool onAttackStop;
            public bool onAttackStart;
            public bool DoAttack
            {
                get
                {
                    return _doAttack;
                }

                set
                {
                    if (value)
                    {
                        onAttackStart = true;
                    }
                    else
                    {
                        onAttackStop = true;
                    }
                    _doAttack = value;
                }
            }
            private bool _doAttack;
        }

        [HideInInspector]
        public ShipInputValues InputValues;
        
        [Header("Attachments")]
        public ShipWeaponBase weaponBase;
        public ShipMovementBase movementBase;
        public ShipAbilityBase abilityBase1;
        public ShipAbilityBase abilityBase2;
        
        [Header("Components")]
        public Rigidbody2D Rigidbody2D;
        

        private void Update()
        {

            if(weaponBase != null) weaponBase.Update(this);
            if(movementBase != null) movementBase.Update(this);
            
            InputValues.onAttackStart = false;
            InputValues.onAttackStop = false;
        }

        public void TriggerAbility1()
        {
            if(abilityBase1 != null) abilityBase1.Trigger(this);
        }
        
        public void TriggerAbility2()
        {
            if(abilityBase2 != null) abilityBase2.Trigger(this);
        }



    }
    
    
}
