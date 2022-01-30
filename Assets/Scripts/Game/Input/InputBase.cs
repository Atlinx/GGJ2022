using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ship;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public abstract class InputBase : MonoBehaviour
    {
        public PlayerInput playerInput;
        public ShipCore shipCore;

        public bool isAbilityOneHeld;
        public bool isAbilityTwoHeld;

        public InputAction attackAction;
        public InputAction ability1Action;
        public InputAction ability2Action;
        public InputAction moveAction;

        protected virtual void Awake()
        {
            attackAction = playerInput.currentActionMap.FindAction("Attack");
            ability1Action = playerInput.currentActionMap.FindAction("Ability 1");
            ability2Action = playerInput.currentActionMap.FindAction("Ability 2");
            moveAction = playerInput.currentActionMap.FindAction("Move");
            Debug.Log("asdfsdf");
        }

        private void OnEnable()
        {
            //playerInput.currentActionMap.FindAction("Attack.performed += shipCore;
            attackAction.started += OnAttackStart;
            ability1Action.started += OnAbility1Start;
            ability2Action.started += OnAbility2Start;

            attackAction.canceled += OnAttackStop;
            ability1Action.canceled += OnAbility1Stop;
            ability2Action.canceled += OnAbility2Stop;
        }

        private void OnDisable()
        {
            attackAction.started -= OnAttackStart;
            ability1Action.started -= OnAbility1Start;
            ability2Action.started -= OnAbility2Start;

            attackAction.canceled -= OnAttackStop;
            ability1Action.canceled -= OnAbility1Stop;
            ability2Action.canceled -= OnAbility2Stop;
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
            shipCore.InputValues.MovementDir = moveAction.ReadValue<Vector2>();
            shipCore.InputValues.AimRotation = Mathf.Rad2Deg * Mathf.Atan2(shipCore.InputValues.AimDir.y, shipCore.InputValues.AimDir.x);
        }
    }

}