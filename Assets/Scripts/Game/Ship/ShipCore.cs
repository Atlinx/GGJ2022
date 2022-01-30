using System;
using Game.Dimensions;
using Game.Player;
using Game.Ship.Abilities;
using Game.Ship.Movement;
using Game.Ship.Weapon;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Ship
{
    public class ShipCore : MonoBehaviour
    {
        [Serializable]
        public struct ShipConfig
        {
            public Transform[] spawnGunLocations;
            public bool DisableMovement;
            public float SpeedMultiplier;

            //If applicable
            public GameObject weaponGameObject;
        }

        public ShipConfig shipConfig;
        
        public struct ShipTempValues
        {
            public float weaponCooldown;
        }

        
        public ShipTempValues tempValues;
        public struct ShipInputValues
        {

            public Vector2 MovementDir;

            public float AimRotation;
            public Vector2 AimDir;

            public event Action OnAttackStart;
            public event Action OnAttackStop;
            public bool isAttackHeld;

            public event Action OnAbility1Start;
            public event Action OnAbility1Stop;
            public bool isAbility1Held;

            public event Action OnAbility2Start;
            public event Action OnAbility2Stop;
            public bool isAbility2Held;

            public event Action OnDimensionStart;
            public event Action OnDimensionStop;
            public bool isDimensionHeld;
            
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
                isAbility1Held = false;
            }

            public void Ability2Start()
            {
                OnAbility2Start?.Invoke();
                isAbility2Held = true;
            }

            public void Ability2Stop()
            {
                OnAbility2Stop?.Invoke();
                isAbility2Held = false;
            }

            public void DimensionStart()
            {
                OnDimensionStart?.Invoke();
                isDimensionHeld = true;
            }

            public void DimensionStop()
            {
                OnDimensionStop?.Invoke();
                isDimensionHeld = false;
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

        [FormerlySerializedAs("core")] [HideInInspector]
        public PlayerCore playerCore;
        private void Awake()
        {
            InputValues.OnAbility1Start += StartAbility1;
            InputValues.OnAbility1Stop += StopAbility1;
            if (abilityBase1 != null) abilityBase1.Pressed = InputValues.isAbility1Held;

            InputValues.OnAbility1Start += StartAbility2;
            InputValues.OnAbility1Stop += StopAbility2;
            if (abilityBase2 != null) abilityBase2.Pressed = InputValues.isAbility2Held;

            InputValues.OnDimensionStart += SwapDimensions;

        }

        private void Update()
        {
            if (weaponBase != null ) weaponBase.UpdateWeapon(this);
            if (movementBase != null && !shipConfig.DisableMovement) movementBase.UpdateMove(this);
            if (abilityBase1 != null) abilityBase1.Update(this);
            if (abilityBase2 != null) abilityBase2.Update(this);
        }

        public void SwapDimensions()
        {
            // TODO : Check cooldown before execution;
            DimensionCore._instance.SwapDimension(this.playerCore);
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
