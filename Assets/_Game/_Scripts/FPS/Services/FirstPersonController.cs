using _Game._Scripts.FPS.Configs;
using _Game._Scripts.FPS.Input;
using UnityEngine;

namespace _Game._Scripts.FPS.Services
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(ControllerInput))]
    public class FirstPersonController : MonoBehaviour
    {
        [Space(5)]
        [SerializeField] private ControllerInput controllerInput;
        [Space(5)]
        [SerializeField] private MovementConfig _movementConfig;

        private Rigidbody _rigidbody;
        private CapsuleCollider _capsuleCollider;
        private PlayerMovement _playerMovement;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
            
            InitMovement();
        }

        private void InitMovement()
        {
            _playerMovement = new PlayerMovement();
            _playerMovement.Init(_movementConfig, controllerInput, _rigidbody);
        }

        private void OnEnable()
        {
            _playerMovement.OnEnable();
        }

        private void Update()
        {
            _playerMovement.Update();
        }

        private void OnDisable()
        {
            _playerMovement.OnDisable();
        }
        
        private void Reset()
        {
            _movementConfig.Reset();
        }
    }
}
