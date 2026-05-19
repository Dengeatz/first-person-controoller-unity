using System;
using _Game._Scripts.FPS.Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.FPS.Services
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class FirstPersonController : MonoBehaviour
    {
        [Space(5)]
        [SerializeField] private MovementConfig _movementConfig;

        public void Reset()
        {
            _movementConfig.Reset();
        }
    }
}
