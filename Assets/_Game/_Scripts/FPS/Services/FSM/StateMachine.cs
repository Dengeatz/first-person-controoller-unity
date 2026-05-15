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
    public abstract class StateMachine<T> where T : class, IStateLifecycle
    {
        readonly Dictionary<Type, T> _states = new();

        /// <summary>Зарегистрированные экземпляры состояний (ключ — <see cref="object.GetType"/> экземпляра).</summary>
        protected IReadOnlyDictionary<Type, T> RegisteredStates => _states;

        public T CurrentState { get; private set; }

        /// <summary>Регистрирует экземпляр состояния; ключ — фактический тип <paramref name="state"/>.</summary>
        protected void RegisterState(T state)
        {
            ArgumentNullException.ThrowIfNull(state);
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
        protected async Task TransitionToAsync(Type stateType, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(stateType);
            if (!_states.TryGetValue(stateType, out var next))
                throw new KeyNotFoundException($"No state registered for type '{stateType.Name}'.");
            await TransitionToAsync(next, cancellationToken);
        }

        /// <summary>Переход в состояние типа <typeparamref name="TState"/>.</summary>
        protected Task TransitionToAsync<TState>(CancellationToken cancellationToken = default)
            where TState : class, T =>
            TransitionToAsync(typeof(TState), cancellationToken);

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
    }
}
