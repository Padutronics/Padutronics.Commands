﻿using System;

namespace Padutronics.Commands;

public sealed class DelegateCommand : Command
{
    private static readonly Func<bool> defaultCanExecuteMethod = () => true;

    private readonly Func<bool> canExecuteMethod;
    private readonly Action executeMethod;

    public DelegateCommand(Action executeMethod) :
        this(executeMethod, defaultCanExecuteMethod)
    {
    }

    public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
    {
        this.canExecuteMethod = canExecuteMethod;
        this.executeMethod = executeMethod;
    }

    public override bool CanExecute()
    {
        return canExecuteMethod();
    }

    public override void Execute()
    {
        executeMethod();
    }
}