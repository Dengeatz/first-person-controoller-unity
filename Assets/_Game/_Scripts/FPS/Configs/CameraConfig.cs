using System;
using UnityEngine;

namespace _Game._Scripts.FPS.Configs
{
    [Serializable]
    public class CameraConfig
    {
        #region Serialized parameters
        [Header("General Parameters")] 
        [Space(2)] 
        [Min(0)] [SerializeField] private float _sensitivity = 1.0f;
        [Space(5)] 
        [Header("Animation Parameters")] 
        [Space(2)]
        [Header("Idle Parameters")]
        [Space(2)]
        [Min(0)] [SerializeField] private float _idleBreathFrequency = 1.0f;
        [Min(0)] [SerializeField] private float _idleBreathAmplitude = 1.0f;
        [Space(5)]
        [Header("Walk Parameters")]
        [Space(2)]
        [Min(0)] [SerializeField] private float _walkBreathFrequency = 2.0f;
        [Min(0)] [SerializeField] private float _walkBreathAmplitude = 2.0f;
        #endregion
        
        #region Public parameters
        public float Sensitivity => _sensitivity;
        public float IdleBreathFrequency => _idleBreathFrequency;
        public float IdleBreathAmplitude => _idleBreathAmplitude;
        public float WalkBreathFrequency => _walkBreathFrequency;
        public float WalkBreathAmplitude => _walkBreathAmplitude;
        #endregion
        
        public void Reset()
        {
            _sensitivity = 1.0f;
            _idleBreathFrequency = 1.0f;
            _idleBreathAmplitude = 1.0f;
            _walkBreathFrequency = 2.0f;
            _walkBreathAmplitude = 2.0f;
        }
    }
}