using System;
using _Game._Scripts.FPS.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game._Scripts.FPS.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class ControllerInput : MonoBehaviour, IInputSystem
    {
        private PlayerInput _playerInput;
        
        public event Action<Vector2> Move; 
        public event Action<Vector2> Look; 
        public event Action Attack;   
        public event Action Interact; 
        public event Action Crouch; 
        public event Action Jump; 
        public event Action Previous; 
        public event Action Next; 
        public event Action Sprint;

        public Vector2 MoveDirection { get; private set; }
        public Vector2 LookDirection { get; private set; }

        public void Awake()
        {
            if (_playerInput == null)
            {
                if (TryGetComponent(out _playerInput) == false)
                {
                    _playerInput = FindAnyObjectByType<PlayerInput>();
                }
            }
            
            _playerInput.onActionTriggered += OnActionTriggered;
        }

        private void OnEnable()
        {
            _playerInput.onActionTriggered += OnActionTriggered;
        }

        private void OnDisable()
        {
            _playerInput.onActionTriggered -= OnActionTriggered;
        }

        private void OnActionTriggered(InputAction.CallbackContext context)
        {
            // Имя действия задаётся в Input Action Asset
            string actionName = context.action.name;

            switch (actionName)
            {
                case "Move":
                    MoveDirection = context.ReadValue<Vector2>();
                    Move?.Invoke(context.ReadValue<Vector2>());
                    break;
                case "Look":
                    LookDirection = context.ReadValue<Vector2>();
                    Look?.Invoke(context.ReadValue<Vector2>());
                    break;
                case "Attack":
                    if (context.performed) Attack?.Invoke();
                    break;
                case "Interact":
                    if (context.performed) Interact?.Invoke();
                    break;
                case "Crouch":
                    if (context.performed) Crouch?.Invoke();
                    break;
                case "Jump":
                    if (context.performed) Jump?.Invoke();
                    break;
                case "Previous":
                    if (context.performed) Previous?.Invoke();
                    break;
                case "Next":
                    if (context.performed) Next?.Invoke();
                    break;
                case "Sprint":
                    if (context.performed) Sprint?.Invoke();
                    break;
            }
        }
    }
}
