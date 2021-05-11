using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Models;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using AutomatingDocumentFilling.WPFNetFramework.Views;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class ShowWindowCommand : ICommand
    {
        private readonly string _documentName;
        private readonly ICommand _openCommand;
        private readonly DocumentViewModel _documentViewModel;

        public ShowWindowCommand(ICommand openCommand,
                                 DocumentViewModel documentViewModel,
                                 string documentName)
        {
            _openCommand = openCommand;
            _documentViewModel = documentViewModel;
            _documentName = documentName;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_documentName.Length > 0)
            {
                _openCommand.Execute(null);
                Window documentWindow = new DocumentView(_documentViewModel);
                documentWindow.Show();
            }
        }
    }
}