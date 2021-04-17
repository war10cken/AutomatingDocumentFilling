using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using AutomatingDocumentFilling.Converter;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Commands
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenDocument();
        }

        private void OpenDocument()
        {
            //string originalPath = "50.docx";

            // OpenFileDialog dlg = new OpenFileDialog();
            //
            // dlg.DefaultExt = ".docx";
            //
            // dlg.Filter = "Word documents (.docx)|*.docx";
            //
            // bool? result = dlg.ShowDialog();

            if (_outputName.Length > 0)
            {
                string path = Path.GetFullPath(_outputName ?? string.Empty);
                string newXpsDocumentName = Path.GetFullPath(_outputName ?? string.Empty).Remove(path.Length - 4) + "xps";
                
                XpsDocument xpsDocument = DocumentConverter.ConvertToXps(path, newXpsDocumentName);

                _viewModel.Document = xpsDocument.GetFixedDocumentSequence();
            }
        }
        
        public event EventHandler CanExecuteChanged;
    }
}