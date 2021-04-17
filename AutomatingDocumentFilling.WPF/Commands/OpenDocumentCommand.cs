using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using AutomatingDocumentFilling.WPF.ViewModels;
using Microsoft.Win32;
using AutomatingDocumentFilling.Converter;
using Microsoft.Office.Interop.Word;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class OpenDocumentCommand : ICommand
    {
        private readonly DocumentViewModel _viewModel;
        private readonly string _documentName;

        public OpenDocumentCommand(DocumentViewModel viewModel, string documentName)
        {
            _viewModel = viewModel;
            _documentName = documentName;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
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

            if (_documentName.Length > 0)
            {
                string path = Path.GetFullPath(_documentName ?? string.Empty);
                string newXpsDocumentName = Path.GetFullPath(_documentName ?? string.Empty).Remove(path.Length - 4) + "xps";
                
                XpsDocument xpsDocument = DocumentConverter.ConvertToXps(path, newXpsDocumentName);

                //XpsDocument xpsDocument = new XpsDocument(newXpsDocumentName, FileAccess.Read);

                _viewModel.Document = xpsDocument.GetFixedDocumentSequence();
            }
        }
        
        public event EventHandler? CanExecuteChanged;
    }
}