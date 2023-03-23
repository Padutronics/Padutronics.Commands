using System.Threading.Tasks;

namespace Padutronics.Commands;

public abstract class AsyncCommand : AsyncCommandBase, IAsyncCommand
{
    public virtual bool CanExecute()
    {
        return true;
    }

    public async void Execute()
    {
        await ExecuteAsync();
    }

    public abstract Task ExecuteAsync();
}