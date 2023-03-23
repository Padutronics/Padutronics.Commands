using System;

namespace Padutronics.Commands;

public sealed class DelegateCommand<TParameter> : Command<TParameter>
{
    private static readonly Func<TParameter, bool> defaultCanExecuteMethod = _ => true;

    private readonly Func<TParameter, bool> canExecuteMethod;
    private readonly Action<TParameter> executeMethod;

    public DelegateCommand(Action<TParameter> executeMethod) :
        this(executeMethod, defaultCanExecuteMethod)
    {
    }

    public DelegateCommand(Action<TParameter> executeMethod, Func<TParameter, bool> canExecuteMethod)
    {
        this.canExecuteMethod = canExecuteMethod;
        this.executeMethod = executeMethod;
    }

    public override bool CanExecute(TParameter parameter)
    {
        return canExecuteMethod(parameter);
    }

    public override void Execute(TParameter parameter)
    {
        executeMethod(parameter);
    }
}