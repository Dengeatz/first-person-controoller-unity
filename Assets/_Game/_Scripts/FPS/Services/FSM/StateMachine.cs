using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using _Game._Scripts.FPS.Interfaces.FSM;

namespace _Game._Scripts.FPS.Services.FSM
{
    /// <summary>
    /// Абстрактная машина состояний: состояния хранятся по <see cref="Type"/>, переход по типу, кадр — через <see cref="Update"/>.
    /// </summary>
    public abstract class StateMachine<T> : IDisposable where T : IStateLifecycle, IDisposable
    {
        readonly Dictionary<Type, T> _states = new();
        private CancellationTokenSource _cts;

        /// <summary>Зарегистрированные экземпляры состояний (ключ — <see cref="object.GetType"/> экземпляра).</summary>
        protected IReadOnlyDictionary<Type, T> RegisteredStates => _states;

        public T CurrentState { get; private set; }

        public abstract void InitStates();
        /// <summary>Регистрирует экземпляр состояния; ключ — фактический тип <paramref name="state"/>.</summary>
        protected void RegisterState(T state)
        {
            if (state == null)
                throw new NullReferenceException();
            
            var type = state.GetType();
            
            if (_states.ContainsKey(type))
                throw new InvalidOperationException($"State '{type.Name}' is already registered.");
            
            _states.Add(type, state);
        }

        /// <summary>Кадр активного состояния; переопределяйте <see cref="IStateLifecycle.Update"/> в нужных T.</summary>
        public void Update()
        {
            CurrentState?.Update();
        }

        /// <summary>Переход по типу зарегистрированного состояния.</summary>
        protected async Task TransitionToAsync(Type stateType)
        {
            if (_cts != null)
            {
                DisposeToken();
            }

            _cts = new();
            
            if (stateType == null)
                throw new NullReferenceException();
            
            if (!_states.TryGetValue(stateType, out var next))
                throw new KeyNotFoundException($"No state registered for type '{stateType.Name}'.");
            await TransitionToAsync(next, _cts.Token);
        }

        /// <summary>Переход в состояние типа <typeparamref name="TState"/>.</summary>
        public Task TransitionToAsync<TState>()
            where TState : class, T =>
            TransitionToAsync(typeof(TState));

        /// <summary>Переход в <paramref name="next"/>: выход из текущего состояния (если есть), затем вход в новое.</summary>
        protected async Task TransitionToAsync(T next, CancellationToken cancellationToken = default)
        {
            if (ReferenceEquals(CurrentState, next))
                return;

            if (CurrentState is { } current)
                await current.OnExitAsync(cancellationToken);

            CurrentState = next;

            if (CurrentState is { } entering)
                await entering.OnEnterAsync(cancellationToken);
        }

        private void DisposeToken()
        {
            _cts?.Dispose();
            _cts?.Cancel();
            _cts = null;
        }
        
        public void Dispose()
        {
            CurrentState?.Dispose();
            DisposeToken();
        }
    }
}
