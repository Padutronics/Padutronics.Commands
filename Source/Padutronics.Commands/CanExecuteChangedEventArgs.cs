using System;

namespace Padutronics.Commands;

public sealed class CanExecuteChangedEventArgs : EventArgs
{
    public new static CanExecuteChangedEventArgs Empty { get; } = new CanExecuteChangedEventArgs();
}