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
            public bool DoAttack;
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
        

        private void Start()
        {
            weaponBase.Init(this);
            movementBase.Init(this);
        }

        private void Update()
        {
            weaponBase.Update();
            movementBase.Update();
        }

        public void TriggerAbility1()
        {
            if(abilityBase1 != null) abilityBase1.Trigger();
        }
        
        public void TriggerAbility2()
        {
            if(abilityBase2 != null) abilityBase2.Trigger();
        }



    }
    
    
}
