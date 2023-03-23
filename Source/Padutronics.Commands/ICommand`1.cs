namespace Padutronics.Commands;

public interface ICommand<in TParameter> : INotifyCanExecuteChanged
{
    bool CanExecute(TParameter parameter);
    void Execute(TParameter parameter);
}