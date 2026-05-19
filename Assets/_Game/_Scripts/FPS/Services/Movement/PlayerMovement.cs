using _Game._Scripts.FPS.Services.Movement;
using _Game._Scripts.FPS.Services.Movement.States;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerMovementStateMachine _playerMovementStateMachine;
    
    private void OnEnable()
    {
        _playerMovementStateMachine = new PlayerMovementStateMachine();
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
