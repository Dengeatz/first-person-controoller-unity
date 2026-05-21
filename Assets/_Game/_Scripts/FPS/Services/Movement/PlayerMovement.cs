using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.Movement;
using _Game._Scripts.FPS.Services.Movement.States;
using UnityEngine;

public class PlayerMovement
{
    private PlayerMovementStateMachine _playerMovementStateMachine;
    private ControllerInput _controllerInput;
    private Rigidbody _rigidbody;
    
    private MovementConfig _movementConfig;

    public void Init(MovementConfig movementConfig, ControllerInput controllerInput, Rigidbody rigidbody)
    {
        _movementConfig = movementConfig;
        _controllerInput = controllerInput;
        _rigidbody = rigidbody;
    }
    
    public void OnEnable()
    {
        _playerMovementStateMachine = new PlayerMovementStateMachine(_controllerInput, _rigidbody, _movementConfig);
        _playerMovementStateMachine.InitStates();
        _playerMovementStateMachine.TransitionToAsync<IdleState>();
    }   

    public void Update()
    {
        _playerMovementStateMachine.Update();
    }

    public void OnDisable()
    {
        _playerMovementStateMachine.Dispose();
    }
}
