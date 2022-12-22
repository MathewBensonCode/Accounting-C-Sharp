using System.Windows.Input;
using AccountsViewModel.CommandViewModels.Interfaces;

namespace AccountsViewModel.CommandViewModels
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
