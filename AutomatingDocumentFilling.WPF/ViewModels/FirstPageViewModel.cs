using System.Windows.Documents;
using System.Windows.Input;
using AutomatingDocumentFilling.WPF.Commands;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.Views;

namespace AutomatingDocumentFilling.WPF.ViewModels
{
    public class FirstPageViewModel : ViewModelBase
    {
        private readonly string _path = @"D:\Download\50.docx";
        
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public ICommand OpenDocumentCommand { get; }

        public ICommand ShowWindowCommand { get; }

        public FirstPageViewModel(IDialogWindowService<DocumentView> dialogWindowService, DocumentViewModel documentViewModel)
        {
            documentViewModel.OpenDocumentCommand = new OpenDocumentCommand(documentViewModel);
            ShowWindowCommand =
                new ShowWindowCommand<DocumentView>(dialogWindowService, this, _path,
                                                    documentViewModel.OpenDocumentCommand);
            // OpenDocumentCommand = new OpenDocumentCommand("123", this);
            // OpenDocumentCommand.Execute(null);
        }
    }
}