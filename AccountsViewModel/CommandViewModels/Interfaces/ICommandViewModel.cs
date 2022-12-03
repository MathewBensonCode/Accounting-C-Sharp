using System.Windows.Input;

namespace AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces
{
    public interface ICommandViewModel
    {
        string CommandName { get; }
        ICommand Command { get; }
    }
}
