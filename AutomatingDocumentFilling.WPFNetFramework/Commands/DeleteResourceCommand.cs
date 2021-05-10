using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class DeleteResourceCommand<TViewModel> : ICommand where TViewModel : ResourceViewModelBase
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly TViewModel _viewModel;

        public DeleteResourceCommand(TViewModel viewModel, HomeViewModel homeViewModel)
        {
            _viewModel = viewModel;
            _homeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string collectionName = _viewModel.GetType().Name.Replace("ViewModel", "");
            var collection = _homeViewModel.GetType().GetProperty(collectionName);

            if (collection?.GetValue(_homeViewModel) is List<TViewModel> newList)
            {
                newList.Remove(_viewModel);
                
                collection.SetValue(_homeViewModel, null);
                
                collection.SetValue(_homeViewModel, newList);                
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}