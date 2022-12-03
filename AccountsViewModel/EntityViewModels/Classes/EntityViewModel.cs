using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AccountLib.Interfaces;
using Prism.Mvvm;

namespace AccountsViewModel.EntityViewModels.Classes
{
    public class EntityViewModel<T>
        : BindableBase, IEntityViewModel<T>, INotifyDataErrorInfo
        where T : class, IDbModel
    {
        protected IDictionary<string, List<string>> _errors;

        public EntityViewModel(T entity,
            IDictionary<string, List<string>> errors)
        {
            Entity = entity;
            _errors = errors;
            HasChanged = false;
            PropertyChanged += ValidateOnPropertyChanged;
        }

        public int Id => Entity.Id;

        public T Entity { get; private set; }

        public bool HasErrors => _errors.Values.Count != 0;

        private bool _hasChanged;
        public bool HasChanged
        {
            get => _hasChanged;
            private set => SetProperty(ref _hasChanged, value);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.TryGetValue(propertyName, out List<string> collection) ? collection : null;
        }

        protected void ValidateOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {

            var propertyname = args.PropertyName;

            if (propertyname != "HasErrors")
            {
                var validationcontext = new ValidationContext(this, null, null)
                {
                    MemberName = propertyname
                };

                var validationresults = new List<ValidationResult>();
                _ = Validator.TryValidateObject(this, validationcontext, validationresults);

                if (_errors.ContainsKey(propertyname))
                {
                    _ = _errors.Remove(propertyname);
                }

                OnErrorsChanged(propertyname);

                HandleValidationResults(validationresults);
            }

            if (HasChanged == false)
            {
                HasChanged = true;
                RaisePropertyChanged("HasChanged");
            }
        }

        private void HandleValidationResults(List<ValidationResult> validationresults)
        {
            //Group validation results by property namdes
            var resultsByPropertyNames = from res in validationresults
                                         from mname in res.MemberNames
                                         group res by mname into g
                                         select g;

            foreach (var prop in resultsByPropertyNames)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (!_errors.ContainsKey(prop.Key))
                {
                    _errors.Add(prop.Key, messages);
                }
                else
                {
                    _errors[prop.Key].AddRange(messages);
                }

                OnErrorsChanged(prop.Key);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            var args = new DataErrorsChangedEventArgs(propertyName);
            ErrorsChanged?.Invoke(this, args);
            RaisePropertyChanged("HasErrors");
        }
    }

}
