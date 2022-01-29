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

            public event Action OnAttackStart;
            public event Action OnAttackStop;
            public bool isAttackHeld;

            public event Action OnAbility1Start;
            public event Action OnAbility1Stop;
            public bool isAbility1Held;

            public event Action OnAbility2Start;
            public event Action OnAbility2Stop;
            public bool isAbility2Held;

            public void AttackStart()
            {
                OnAttackStart?.Invoke();
                isAttackHeld = true;
            }

            public void AttackStop()
            {
                OnAttackStop?.Invoke();
                isAttackHeld = false;
            }

            public void Ability1Start()
            {
                OnAbility1Start?.Invoke();
                isAbility1Held = true;
            }

            public void Ability1Stop()
            {
                OnAbility1Stop?.Invoke();
                isAbility1Held = true;
            }

            public void Ability2Start()
            {
                OnAbility2Start?.Invoke();
                isAbility2Held = true;
            }

            public void Ability2Stop()
            {
                OnAbility2Stop?.Invoke();
                isAbility2Held = true;
            }
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

        private void Awake()
        {
            InputValues.OnAbility1Start += StartAbility1;
            InputValues.OnAbility1Stop += StopAbility1;
            abilityBase1.Pressed = InputValues.isAbility1Held;

            InputValues.OnAbility1Start += StartAbility2;
            InputValues.OnAbility1Stop += StopAbility2;
            abilityBase1.Pressed = InputValues.isAbility2Held;
        }

        private void Update()
        {
            if(weaponBase != null) weaponBase.Update(this);
            if(movementBase != null) movementBase.Update(this);
            if (abilityBase1 != null) abilityBase1.Update(this);
            if (abilityBase1 != null) abilityBase2.Update(this);
        }

        public void StartAbility1()
        {
            if (abilityBase1 != null) abilityBase1.Start(this);
        }

        public void StopAbility1()
        {
            if (abilityBase1 != null) abilityBase1.Stop(this);
        }
        public void StartAbility2()
        {
            if (abilityBase2 != null) abilityBase2.Start(this);
        }

        public void StopAbility2()
        {
            if (abilityBase2 != null) abilityBase2.Stop(this);
        }
    }
}
