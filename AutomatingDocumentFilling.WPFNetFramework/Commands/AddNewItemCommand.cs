using System;
using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class AddNewItemCommand<TViewModel> : ICommand where TViewModel : ViewModelBase, new()
    {
        private readonly HomeViewModel _homeViewModel;
        private static readonly List<TViewModel> _list = new();
        private readonly string _propertyName;
        private readonly string _propertyNameOfCount;

        public AddNewItemCommand(HomeViewModel homeViewModel, string propertyName, string propertyNameOfCount)
        {
            _homeViewModel = homeViewModel;
            _propertyName = propertyName;
            _propertyNameOfCount = propertyNameOfCount;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var homeViewModelProperty = _homeViewModel.GetType().GetProperty(_propertyName);
            var homeViewModelCountProperty = _homeViewModel.GetType().GetProperty(_propertyNameOfCount);
            
            homeViewModelProperty?.SetValue(_homeViewModel, null);
            _list.Clear();

            int count = int.Parse((string) homeViewModelCountProperty.GetValue(_homeViewModel));
            
            for(int i = 0; i < count; i++)
                _list.Add(new TViewModel());
            
            homeViewModelProperty?.SetValue(_homeViewModel, _list);
        }

        public event EventHandler CanExecuteChanged;
    }
}