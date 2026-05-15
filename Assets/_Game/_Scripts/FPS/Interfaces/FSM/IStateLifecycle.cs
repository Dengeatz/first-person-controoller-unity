using System.Threading;
using System.Threading.Tasks;

namespace _Game._Scripts.FPS.Interfaces.FSM
{
    /// <summary>
    /// Жизненный цикл состояния: по умолчанию мгновенный вход/выход и пустой кадр;
    /// при необходимости переопределяйте в конкретном типе состояния.
    /// </summary>
    public interface IStateLifecycle
    {
        Task OnEnterAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        Task OnExitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        void Update() { }
    }
}
