using System.Windows.Input;
using AccountsViewModel.CommandViewModels;
using AccountsViewModel.CommandViewModels.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests
{
    public class CommandViewModelTests
    {
        private readonly CommandViewModel sut;
        private readonly Mock<ICommand> command;

        public CommandViewModelTests()
        {
            command = new Mock<ICommand>();
            sut = new CommandViewModel(
                command.Object
                );
        }
        [Fact]
        public void ShouldBeOfTypeICommandViewModel()
        {
            Assert.IsAssignableFrom<ICommandViewModel>(sut);
        }

        [Fact]
        public void ShouldHaveAStringName()
        {
            Assert.IsType<string>(sut.CommandName);
        }

        [Fact]
        public void ShouldHaveAnICommandProperty()
        {
            Assert.IsAssignableFrom<ICommand>(sut.Command);
        }
    }
}
