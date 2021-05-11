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
        private readonly string _propertyNameOfCount;

        public AddNewItemCommand(TMainViewModel mainViewModel, string propertyName, string propertyNameOfCount = null)
        {
            _mainViewModel = mainViewModel;
            _propertyName = propertyName;
            _propertyNameOfCount = propertyNameOfCount;
            _list = new List<TViewModel>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_propertyNameOfCount != null)
            {
                int count = 0;

                var collectionWithSpecificCount = _mainViewModel.GetType().GetProperty(_propertyName);
                var homeViewModelCountProperty = _mainViewModel.GetType().GetProperty(_propertyNameOfCount);
                var constructorInfoWithSpecificCount = typeof(TViewModel).GetConstructor(new[] { typeof(HomeViewModel) });

                collectionWithSpecificCount?.SetValue(_mainViewModel, null);
                _list.Clear();

                try
                {
                    count = int.Parse((string)homeViewModelCountProperty?.GetValue(_mainViewModel) ?? string.Empty);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Вы не ввели количество");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Вы не ввели количество");
                }

                for (int i = 0; i < count; i++)
                {
                    _list.Add(constructorInfoWithSpecificCount != null 
                                  ? (TViewModel)Activator.CreateInstance(typeof(TViewModel), _mainViewModel)
                                  : (TViewModel)Activator.CreateInstance(typeof(TViewModel)));
                }

                collectionWithSpecificCount?.SetValue(_mainViewModel, _list);
                return;
            }

            var constructorInfo = typeof(TViewModel).GetConstructor(new[] { typeof(HomeViewModel) });

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