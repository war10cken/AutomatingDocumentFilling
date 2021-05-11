using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class CourseWorkViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand DeleteCommand { get; }

        public CourseWorkViewModel(HomeViewModel homeViewModel)
        {
            DeleteCommand = new DeleteItemCommand<CourseWorkViewModel>(this, homeViewModel);
        }
    }
}