using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.FSM;
using _Game._Scripts.FPS.Services.Movement.States;
using UnityEngine;

namespace _Game._Scripts.FPS.Services.Movement
{
    public class PlayerMovementStateMachine : StateMachine<MovementState>
    {
        private readonly ControllerInput _controllerInput;
        private readonly Rigidbody _rigidbody;
        private readonly MovementConfig _movementConfig;
        
        public PlayerMovementStateMachine(ControllerInput controllerInput, Rigidbody rigidbody, MovementConfig movementConfig)
        {
            _controllerInput = controllerInput;
            _rigidbody = rigidbody;
            _movementConfig = movementConfig;
        }
        
        public override void InitStates()
        {
            RegisterState(new IdleState(_movementConfig, _rigidbody, _controllerInput, this));
            RegisterState(new WalkState(_movementConfig, _rigidbody, _controllerInput, this));
        }
    }
}