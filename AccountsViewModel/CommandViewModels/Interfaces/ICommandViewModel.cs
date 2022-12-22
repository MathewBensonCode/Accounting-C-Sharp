using System.Windows.Input;

namespace AccountsViewModel.CommandViewModels.Interfaces
{
    public interface ICommandViewModel
    {
        string CommandName { get; }
        ICommand Command { get; }
    }
}
