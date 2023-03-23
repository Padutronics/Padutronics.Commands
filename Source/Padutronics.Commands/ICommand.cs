namespace Padutronics.Commands;

public interface ICommand : INotifyCanExecuteChanged
{
    bool CanExecute();
    void Execute();
}