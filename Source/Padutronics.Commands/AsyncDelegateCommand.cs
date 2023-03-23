using System;
using System.Threading.Tasks;

namespace Padutronics.Commands;

public sealed class AsyncDelegateCommand : AsyncCommand
{
    private static readonly Func<bool> defaultCanExecuteMethod = () => true;

    private readonly Func<bool> canExecuteMethod;
    private readonly Func<Task> executeMethod;

    public AsyncDelegateCommand(Func<Task> executeMethod) :
        this(executeMethod, defaultCanExecuteMethod)
    {
    }

    public AsyncDelegateCommand(Func<Task> executeMethod, Func<bool> canExecuteMethod)
    {
        this.canExecuteMethod = canExecuteMethod;
        this.executeMethod = executeMethod;
    }

    public override bool CanExecute()
    {
        return !IsExecuting && canExecuteMethod();
    }

    public override async Task ExecuteAsync()
    {
        try
        {
            IsExecuting = true;

            RaiseCanExecuteChanged();

            await executeMethod();
        }
        finally
        {
            IsExecuting = false;

            RaiseCanExecuteChanged();
        }
    }
}