using System.Threading.Tasks;

namespace Padutronics.Commands;

public abstract class AsyncCommand<TParameter> : AsyncCommandBase, IAsyncCommand<TParameter>
{
    public virtual bool CanExecute(TParameter parameter)
    {
        return true;
    }

    public async void Execute(TParameter parameter)
    {
        await ExecuteAsync(parameter);
    }

    public abstract Task ExecuteAsync(TParameter parameter);
}