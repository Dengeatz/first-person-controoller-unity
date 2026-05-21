using System;
using System.Threading;
using System.Threading.Tasks;
using _Game._Scripts.FPS.Interfaces.FSM;

namespace _Game._Scripts.FPS.Services.FSM
{
    public abstract class State<T> : IStateLifecycle, IDisposable
        where T : State<T>
    {
        protected StateMachine<T> StateMachine { get; }

        protected State(StateMachine<T> stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual Task OnEnterAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
        public virtual Task OnExitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public virtual void Update() { }
        public void Dispose() { }
    }
}
