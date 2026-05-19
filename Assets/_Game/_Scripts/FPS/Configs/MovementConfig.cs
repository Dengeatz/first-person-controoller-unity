using System;
using UnityEngine;

namespace _Game._Scripts.FPS.Configs
{
    [Serializable]
    public struct MovementConfig
    {
        #region Serialize parameters
        [Header("Walk")]
        [Space(2)]
        [Min(0)] [SerializeField] private float _walkSpeed;
        [Space(5)]
        [Header("Run")]
        [Space(2)]
        [Min(0)] [SerializeField] private float _runSpeed;
        [Space(5)]
        [Header("Physics powers")]
        [Space(2)]
        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private float _groundCheckOriginOffset;
        [SerializeField] private float _gravityCompensationFactor;
        [SerializeField] private float _accumulateSpeed;
        [SerializeField] private float _accumulateSpeedInAir;
        [SerializeField] private float _dragSpeed;
        [SerializeField] private float _dragSpeedInAir;
        #endregion
        
        #region Public parameters
        private float WalkSpeed => _walkSpeed;
        private float RunSpeed => _runSpeed;
        private float GroundCheckDistance => _groundCheckDistance; 
        private float GroundCheckOriginOffset => _groundCheckOriginOffset;
        private float GravityCompensationFactor => _gravityCompensationFactor;
        private float AccumulateSpeed => _accumulateSpeed;
        private float AccumulateSpeedInAir => _accumulateSpeedInAir;
        private float DragSpeed => _dragSpeed;
        private float DragSpeedInAir => _dragSpeedInAir;
        #endregion
        
        
        public void Reset()
        {
            _walkSpeed = 5;
            _runSpeed = 10;
            _groundCheckDistance = 0.2f;
            _groundCheckOriginOffset = 0.1f;
            _gravityCompensationFactor = 0.5f;
            _accumulateSpeed = 1f;
            _accumulateSpeedInAir = 1f;
            _dragSpeed = 1f;
            _dragSpeedInAir = 1f;
        }
    }
}