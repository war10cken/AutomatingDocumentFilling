using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class AddNewItemCommand<TMainViewModel, TViewModel> : ICommand
        where TViewModel : ViewModelBase
        where TMainViewModel : ViewModelBase
    {
        private readonly TMainViewModel _mainViewModel;
        private readonly List<TViewModel> _list;
        private readonly string _propertyName;

        public AddNewItemCommand(TMainViewModel mainViewModel, string propertyName)
        {
            _mainViewModel = mainViewModel;
            _propertyName = propertyName;
            _list = new List<TViewModel>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var constructorInfo = typeof(TViewModel).GetConstructor(new[] { typeof(TMainViewModel) });

            var collectionWithoutSpecificCount = _mainViewModel.GetType().GetProperty(_propertyName);

            collectionWithoutSpecificCount?.SetValue(_mainViewModel, null);

            _list.Add(constructorInfo != null
                          ? (TViewModel)Activator.CreateInstance(typeof(TViewModel), _mainViewModel)
                          : (TViewModel)Activator.CreateInstance(typeof(TViewModel)));

            collectionWithoutSpecificCount?.SetValue(_mainViewModel, _list);
        }

        public event EventHandler CanExecuteChanged;
    }
}