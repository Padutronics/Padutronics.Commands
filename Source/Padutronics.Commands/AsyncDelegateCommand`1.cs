using System;
using System.Threading.Tasks;

namespace Padutronics.Commands;

public sealed class AsyncDelegateCommand<TParameter> : AsyncCommand<TParameter>
{
    private static readonly Func<TParameter, bool> defaultCanExecuteMethod = _ => true;

    private readonly Func<TParameter, bool> canExecuteMethod;
    private readonly Func<TParameter, Task> executeMethod;

    public AsyncDelegateCommand(Func<TParameter, Task> executeMethod) :
        this(executeMethod, defaultCanExecuteMethod)
    {
    }

    public AsyncDelegateCommand(Func<TParameter, Task> executeMethod, Func<TParameter, bool> canExecuteMethod)
    {
        this.canExecuteMethod = canExecuteMethod;
        this.executeMethod = executeMethod;
    }

    public override bool CanExecute(TParameter parameter)
    {
        return !IsExecuting && canExecuteMethod(parameter);
    }

    public override async Task ExecuteAsync(TParameter parameter)
    {
        try
        {
            IsExecuting = true;

            RaiseCanExecuteChanged();

            await executeMethod(parameter);
        }
        finally
        {
            IsExecuting = false;

            RaiseCanExecuteChanged();
        }
    }
}