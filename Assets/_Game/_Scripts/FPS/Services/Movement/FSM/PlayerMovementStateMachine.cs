using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.FSM;
using _Game._Scripts.FPS.Services.Movement.States;

namespace _Game._Scripts.FPS.Services.Movement
{
    public class PlayerMovementStateMachine : StateMachine<MovementState>
    {
        private readonly PlayerInput _playerInput;
        
        public PlayerMovementStateMachine(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }
        
        public override void InitStates()
        {
            RegisterState(new IdleState());
            RegisterState(new WalkState());
        }
    }
}