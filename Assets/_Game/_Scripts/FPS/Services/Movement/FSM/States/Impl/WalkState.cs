using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.FSM;
using UnityEngine;

namespace _Game._Scripts.FPS.Services.Movement.States
{
    public class WalkState : MovementState
    {
        private readonly Rigidbody _rigidbody;
        private readonly ControllerInput _input;
        
        public WalkState(MovementConfig movementConfig, Rigidbody rigidbody, ControllerInput input, StateMachine<MovementState> stateMachine)
            : base(movementConfig, stateMachine)
        {
            _rigidbody = rigidbody;
            _input = input;
        }

        public override void Update()
        {
            UnityEngine.Debug.Log($"Move State: {_input.MoveDirection.magnitude}");

            if (_input.MoveDirection == Vector2.zero)
            {
                StateMachine.TransitionToAsync<IdleState>();
            }
        }
    }
}