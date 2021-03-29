using System;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using AutomatingDocumentFilling.WPF.Commands;
using Microsoft.Office.Interop.Word;

namespace AutomatingDocumentFilling.WPF.ViewModels
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

        public DocumentViewModel()
        {
            // OpenDocumentCommand = new OpenDocumentCommand(this);
            // OpenDocumentCommand.Execute(null);
        }
    }
}