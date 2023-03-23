using System;

namespace Padutronics.Commands;

public abstract class CommandBase : ICanExecuteChangedRaisable, INotifyCanExecuteChanged
{
    public event EventHandler<CanExecuteChangedEventArgs>? CanExecuteChanged;

    protected virtual void OnCanExecuteChanged(CanExecuteChangedEventArgs e)
    {
        CanExecuteChanged?.Invoke(this, e);
    }

    public void RaiseCanExecuteChanged()
    {
        OnCanExecuteChanged(CanExecuteChangedEventArgs.Empty);
    }
}