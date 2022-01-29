using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public abstract class InputBase : MonoBehaviour
    {
        public PlayerControls playerControls;
        public ShipCore shipCore;

        public bool isAbilityOneHeld;
        public bool isAbilityTwoHeld;

        private void OnEnable()
        {
            playerControls.Enable();

            //playerControls.Player.Attack.performed += shipCore;
            playerControls.Player.Attack.started += OnAttackStart;
            playerControls.Player.Ability1.started += OnAbility1Start;
            playerControls.Player.Ability2.started += OnAbility2Start;

            playerControls.Player.Attack.canceled += OnAttackStop;
            playerControls.Player.Ability1.canceled += OnAbility1Stop;
            playerControls.Player.Ability2.canceled += OnAbility2Stop;
        }

        private void OnAbility1Stop(InputAction.CallbackContext obj)
        {
            shipCore.InputValues.Ability1Stop();
        }

        private void OnAbility2Stop(InputAction.CallbackContext obj)
        {
            shipCore.InputValues.Ability2Stop();
        }

        private void OnAttackStop(InputAction.CallbackContext obj)
        {
            shipCore.InputValues.AttackStop();
        }

        private void OnAbility2Start(InputAction.CallbackContext obj)
        {
            shipCore.InputValues.Ability2Start();
        }

        private void OnAbility1Start(InputAction.CallbackContext obj)
        {
            shipCore.InputValues.Ability1Start();
        }

        private void OnAttackStart(InputAction.CallbackContext obj)
        {
            shipCore.InputValues.AttackStart();
        }

        protected virtual void Update()
        {
            shipCore.InputValues.MovementDir = playerControls.Player.Move.ReadValue<Vector2>();
            shipCore.InputValues.MovementRotation = Mathf.Rad2Deg * Mathf.Atan2(shipCore.InputValues.MovementDir.y, shipCore.InputValues.MovementDir.x);
        }
    }

}