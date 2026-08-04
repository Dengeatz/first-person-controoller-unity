using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.Camera.FSM.States;
using _Game._Scripts.FPS.Services.FSM;
using UnityEngine;

namespace _Game._Scripts.FPS.Services.Camera.FSM
{
    public class PlayerCameraStateMachine : StateMachine<CameraState>
    {
        private readonly ControllerInput _controllerInput;
        private readonly PlayerMovement _playerMovement;
        private readonly CameraConfig _cameraConfig;
        
        public PlayerCameraStateMachine(ControllerInput controllerInput, PlayerMovement playerMovement, CameraConfig cameraConfig)
        {
            _controllerInput = controllerInput;
            _playerMovement = playerMovement;
            _cameraConfig = cameraConfig;
        }
        
        public override void InitStates()
        {
            RegisterState(new IdleState(_movementConfig, _rigidbody, _controllerInput, this));
            RegisterState(new WalkState(_movementConfig, _rigidbody, _controllerInput, this));        }
    }
}