using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.ViewModels;
using AutomatingDocumentFilling.WPF.Views;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class ShowWindowCommand<T> : ICommand where T : Window
    {
        private readonly IDialogWindowService<T> _dialogWindowService;
        private readonly FirstPageViewModel _firstPageViewModel;
        private readonly string _path;
        private readonly ICommand _openCommand;

        public ShowWindowCommand(IDialogWindowService<T> dialogWindowService,
                                 FirstPageViewModel firstPageViewModel,
                                 string path, 
                                 ICommand openCommand)
        {
            _dialogWindowService = dialogWindowService;
            _firstPageViewModel = firstPageViewModel;
            _path = path;
            _openCommand = openCommand;
        }

        public bool CanExecute(object? parameter)
        {
            //ОП.06 ОХРАНА ТРУДА
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_path.Length > 0)
            {
                using (var document = DocX.Load(_path))
                {
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        document.ReplaceText("<code>", _firstPageViewModel.Text, false, RegexOptions.IgnoreCase);
                        document.SaveAs(@"D:\Download\50-changed.docx");
                    }
                }

                _openCommand.Execute(null);
                _dialogWindowService.Show();                
            }
            
        }

        public event EventHandler? CanExecuteChanged;
    }
}