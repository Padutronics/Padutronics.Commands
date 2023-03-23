namespace Padutronics.Commands;

public abstract class Command<TParameter> : CommandBase, ICommand<TParameter>
{
    public virtual bool CanExecute(TParameter parameter)
    {
        return true;
    }

    public abstract void Execute(TParameter parameter);
}