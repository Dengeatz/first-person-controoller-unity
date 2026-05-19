using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using _Game._Scripts.FPS.Services.Movement;
using _Game._Scripts.FPS.Services.Movement.States;
using UnityEngine;

public class PlayerMovement
{
    private PlayerMovementStateMachine _playerMovementStateMachine;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    
    private MovementConfig _movementConfig;

    private void Init(MovementConfig movementConfig, PlayerInput playerInput, Rigidbody rigidbody)
    {
        _movementConfig = movementConfig;
        _playerInput = playerInput;
        _rigidbody = rigidbody;
    }
    
    private void OnEnable()
    {
        _playerMovementStateMachine = new PlayerMovementStateMachine(_playerInput);
        _playerMovementStateMachine.InitStates();
        _playerMovementStateMachine.TransitionToAsync<IdleState>();
    }   

    private void Update()
    {
        _playerMovementStateMachine.Update();
    }

    private void OnDisable()
    {
        _playerMovementStateMachine.Dispose();
    }
}
