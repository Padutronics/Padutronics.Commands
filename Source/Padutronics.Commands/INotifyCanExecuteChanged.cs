using System;

namespace Padutronics.Commands;

public interface INotifyCanExecuteChanged
{
    event EventHandler<CanExecuteChangedEventArgs>? CanExecuteChanged;
}