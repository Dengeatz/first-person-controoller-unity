using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Services.FSM;

namespace _Game._Scripts.FPS.Services.Camera.FSM.States
{
    public class CameraState : State<CameraState>
    {
        protected CameraConfig Config { get; }
        
        protected CameraState(CameraConfig config, StateMachine<CameraState> stateMachine) : base(stateMachine)
        {
            Config = config;
        }
    }
}