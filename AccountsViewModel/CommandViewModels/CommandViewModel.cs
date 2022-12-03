using System.Windows.Input;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class CommandViewModel : ICommandViewModel
    {
        public CommandViewModel(ICommand command)
        {
            Command = command;
        }

       public string CommandName => "Add New...";

        public ICommand Command { get; protected set; }
    }
}
