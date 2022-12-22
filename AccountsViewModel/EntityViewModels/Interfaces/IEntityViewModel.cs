using System.ComponentModel;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IEntityViewModel<T>
        : INotifyPropertyChanged
        where T : class
    {
        int Id { get; }
        T Entity { get; }
        bool HasErrors { get; }
        bool HasChanged { get; }
    }
}
