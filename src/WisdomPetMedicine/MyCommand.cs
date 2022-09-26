using System.Windows.Input;

namespace WisdomPetMedicine;
public class MyCommand : ICommand
{
    Action action;
    private readonly Func<bool> canExecute;

    public MyCommand(Action action, Func<bool> canExecute)
    {
        this.action = action;
        this.canExecute = canExecute;
    }
    public void Execute(object parameter)
    {
        action();
    }

    public bool CanExecute(object parameter)
    {
        return canExecute();
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler CanExecuteChanged;
   
}
