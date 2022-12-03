using System;
using System.Collections.Generic;
using System.Linq;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCollectionCopyService
{
    public class ViewModelCollectionCopyService<T>
        : IViewModelCollectionCopyService<T>
        where T : class
    {
        IViewModelFactory<T> _viewmodelfactory;
        IViewModelCopyService<T> _viewmodelcopyservice;

        public ViewModelCollectionCopyService(
            IViewModelCopyService<T> viewmodelcopyservice,
            IViewModelFactory<T> viewmodelfactory)
        {
            _viewmodelcopyservice = viewmodelcopyservice;
            _viewmodelfactory = viewmodelfactory;
        }


        public void CopyCollection(IEntityCollectionViewModel<T> copyfrom, IEntityCollectionViewModel<T> copyto)
        {
            var originalcollection = (copyfrom.CollectionViewState as ICollectionListViewModelState<T>).EntityCollection;
            var copycollection = (copyto.CollectionViewState as ICollectionListViewModelState<T>).EntityCollection;


            if (copycollection.Count > 0)
            {
                if (originalcollection.Count > copycollection.Count)
                {
                    foreach (IEntityViewModel<T> entity in originalcollection)
                    {
                        IEntityViewModel<T> copyentity = containsentity(entity, copycollection as IEnumerable<IEntityViewModel<T>>);
                        if (copyentity == null)
                        {
                            copyentity = GetNewEntity(entity);
                           // copyentity.Entity.Id = entity.Id;
                            _viewmodelcopyservice.CopyEntityViewModel(entity, copyentity);
                            copycollection.Add(copyentity);
                        }
                        else
                        {
                            CopyIfChanged(entity, copyentity);
                        }
                    }
                }

                else if (originalcollection.Count < copycollection.Count)
                {
                    var removallist = new List<IEntityViewModel<T>>();
                    foreach (IEntityViewModel<T> entity in copycollection)
                    {
                        IEntityViewModel<T> checkentity = containsentity(entity, originalcollection as IEnumerable<IEntityViewModel<T>>);
                        if (checkentity == null)
                        {
                            removallist.Add(entity);
                        }
                        else
                        {
                            CopyIfChanged(entity, checkentity);
                        }
                    }

                    foreach (IEntityViewModel<T> entity in removallist)
                    {
                        copycollection.Remove(entity);
                    }
                }

                else if (originalcollection.Count == copycollection.Count)
                {
                    foreach (var pair in originalcollection.Zip(copycollection, Tuple.Create))
                    {
                        CopyIfChanged(pair.Item1, pair.Item2);
                    }
                }
            }
            else if (copycollection.Count == 0)
            {
                foreach (IEntityViewModel<T> entity in originalcollection)
                {
                    var newentity = GetNewEntity(entity);
                    _viewmodelcopyservice.CopyEntityViewModel(entity, newentity);
                    //newentity.Entity.Id = entity.Id;
                    copycollection.Add(newentity);
                }
            }
        }


        IEntityViewModel<T> containsentity(IEntityViewModel<T> entity, IEnumerable<IEntityViewModel<T>> collection)
        {
            foreach (IEntityViewModel<T> ent in collection)
            {
                if (ent.Id == entity.Id)
                    return ent;
            }
            return null;
        }

        void CopyIfChanged(IEntityViewModel<T> original, IEntityViewModel<T> copy)
        {
            if (original.HasChanged)
            {
                _viewmodelcopyservice.CopyEntityViewModel(original, copy);
            }
        }

        IEntityViewModel<T> GetNewEntity(IEntityViewModel<T> entityvm)
        {
            return _viewmodelfactory.CreateViewModelForNewEntity(GetEntityType(entityvm.Entity));
        }

        virtual protected string GetEntityType(object entity){
            return null;
        }


    }
}
