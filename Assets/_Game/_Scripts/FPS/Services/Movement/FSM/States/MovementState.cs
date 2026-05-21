using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Services.FSM;

namespace _Game._Scripts.FPS.Services.Movement.States
{
    public abstract class MovementState : State<MovementState>
    {
        protected MovementConfig Config { get; }

        protected MovementState(MovementConfig movementConfig, StateMachine<MovementState> stateMachine)
            : base(stateMachine)
        {
            Config = movementConfig;
        }
    }
}
