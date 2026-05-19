using System;
using _Game._Scripts.FPS.Interfaces.FSM;

namespace _Game._Scripts.FPS.Services.FSM
{
    public abstract class State : IStateLifecycle, IDisposable
    {
        public void Dispose() { }
    }
}