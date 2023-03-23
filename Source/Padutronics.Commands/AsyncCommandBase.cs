namespace Padutronics.Commands;

public abstract class AsyncCommandBase : CommandBase
{
    public bool IsExecuting { get; protected set; }
}