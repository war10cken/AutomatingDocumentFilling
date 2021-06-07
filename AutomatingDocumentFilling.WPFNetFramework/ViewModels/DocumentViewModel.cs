using AutomatingDocumentFilling.WPFNetFramework.Commands;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class DocumentViewModel : ViewModelBase
    {
        private IDocumentPaginatorSource _document;

        public IDocumentPaginatorSource Document
        {
            get => _document;
            set
            {
                _document = value;
                OnPropertyChanged(nameof(Document));
            }
        }

        public ICommand OpenDocumentCommand { get; set; }

        public ICommand OpenFileCommand { get; }

        public DocumentViewModel(string outputFileName)
        {
            OpenFileCommand = new OpenFileCommand(outputFileName);
        }
    }
}