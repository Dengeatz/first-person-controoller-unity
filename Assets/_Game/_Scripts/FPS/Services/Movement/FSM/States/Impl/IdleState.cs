using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.FSM;
using UnityEngine;

namespace _Game._Scripts.FPS.Services.Movement.States
{
    public class IdleState : MovementState
    {
        private readonly Rigidbody _rigidbody;
        private readonly ControllerInput _input;
        
        public IdleState(MovementConfig config, Rigidbody rigidbody, ControllerInput input, StateMachine<MovementState> stateMachine)
            : base(config, stateMachine)
        {
            _rigidbody = rigidbody;
            _input = input;
        }

        public override void Update()
        {
            UnityEngine.Debug.Log("Idle State");
            
            if (_input.MoveDirection != Vector2.zero)
            {
                StateMachine.TransitionToAsync<WalkState>();
            }
        }
    }
}