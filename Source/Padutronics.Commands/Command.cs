namespace Padutronics.Commands;

public abstract class Command : CommandBase, ICommand
{
    public virtual bool CanExecute()
    {
        return true;
    }

    public abstract void Execute();
}