using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class DeleteItemCommand<TMainViewModel, TViewModel> : ICommand
        where TViewModel : ViewModelBase
        where TMainViewModel : ViewModelBase
    {
        private readonly TMainViewModel _mainViewModel;
        private readonly TViewModel _viewModel;

        public DeleteItemCommand(TViewModel viewModel, TMainViewModel mainViewModel)
        {
            _viewModel = viewModel;
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string collectionName = _viewModel.GetType().Name.Replace("ViewModel", "") + "s";
            var collection = _mainViewModel.GetType().GetProperty(collectionName);

            if (collection?.GetValue(_mainViewModel) is List<TViewModel> newList)
            {
                newList.Remove(_viewModel);

                collection.SetValue(_mainViewModel, null);

                collection.SetValue(_mainViewModel, newList);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}