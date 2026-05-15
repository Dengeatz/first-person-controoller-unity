using System;
using _Game._Scripts.FPS.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game._Scripts.FPS.Input
{
    public class PlayerInput : IInputSystem
    {
        public event Action<Vector2> Move; 
        public event Action<Vector2> Look; 
        public event Action Attack; 
        public event Action Interact; 
        public event Action Crouch; 
        public event Action Jump; 
        public event Action Previous; 
        public event Action Next; 
        public event Action Sprint; 
        
        public void InitializeInput()
        {
            
        }
        
        
        
    }
}
