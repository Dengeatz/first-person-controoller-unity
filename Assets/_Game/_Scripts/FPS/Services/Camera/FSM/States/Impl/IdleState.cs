using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Services.FSM;

namespace _Game._Scripts.FPS.Services.Camera.FSM.States.Impl
{
    public class IdleState : CameraState
    {
        private readonly CameraConfig _config;
        private readonly PlayerMovement _playerMovement;
        
        public IdleState(CameraConfig config, StateMachine<CameraState> stateMachine) : base(config, stateMachine)
        {
            _config = config;
        }
    }
}