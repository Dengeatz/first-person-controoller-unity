using _Game._Scripts.FPS.Services.FSM;
using _Game._Scripts.FPS.Services.Movement.States;

namespace _Game._Scripts.FPS.Services.Movement
{
    public class PlayerMovementStateMachine : StateMachine<MovementState>
    {
        public override void InitStates()
        {
            RegisterState(new IdleState());
            RegisterState(new WalkState());
        }
    }
}