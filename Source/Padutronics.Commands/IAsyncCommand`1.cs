using System.Threading.Tasks;

namespace Padutronics.Commands;

public interface IAsyncCommand<in TParameter> : ICommand<TParameter>
{
    bool IsExecuting { get; }

    Task ExecuteAsync(TParameter parameter);
}