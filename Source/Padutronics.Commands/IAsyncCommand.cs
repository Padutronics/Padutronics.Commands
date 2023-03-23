using System.Threading.Tasks;

namespace Padutronics.Commands;

public interface IAsyncCommand : ICommand
{
    bool IsExecuting { get; }

    Task ExecuteAsync();
}