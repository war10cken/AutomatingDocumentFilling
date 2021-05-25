using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Xps.Packaging;
using AutomatingDocumentFilling.Converter;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class OpenDocumentCommand : ICommand
    {
        private readonly DocumentViewModel _viewModel;
        private readonly string _outputName;

        public OpenDocumentCommand(DocumentViewModel viewModel, string outputName)
        {
            _viewModel = viewModel;
            _outputName = outputName;
        }

        private void OpenDocument()
        {
            if (_outputName.Length > 0)
            {
                string path = Path.GetFullPath(_outputName ?? string.Empty);
                string newXpsDocumentName = Path.GetFullPath(_outputName ?? string.Empty).Remove(path.Length - 4) + "xps";

                DocumentConverter.ConvertToXps(path, newXpsDocumentName);

                XpsDocument xpsDocument = new XpsDocument(newXpsDocumentName, FileAccess.Read);

                _viewModel.Document = xpsDocument.GetFixedDocumentSequence();
                xpsDocument.Close();
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenDocument();
        }

        public event EventHandler CanExecuteChanged;
    }
}