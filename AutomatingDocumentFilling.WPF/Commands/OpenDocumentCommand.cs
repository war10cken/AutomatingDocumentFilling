using System;
using System.IO;
using System.IO.Packaging;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;
using AutomatingDocumentFilling.WPF.ViewModels;
using Microsoft.Win32;
using Spire.Doc;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class OpenDocumentCommand : ICommand
    {
        private readonly DocumentViewModel _viewModel;
        private readonly string _changedFilePath = @"D:\Download\50-changed.docx";

        public OpenDocumentCommand(DocumentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OpenDocument();
        }

        public event EventHandler? CanExecuteChanged;

        private void OpenDocument()
        {
            string originalPath = @"D:\Download\50.docx";
            
            // OpenFileDialog dlg = new OpenFileDialog();
            //
            // dlg.DefaultExt = ".docx";
            //
            // dlg.Filter = "Word documents (.docx)|*.docx";
            //
            // bool? result = dlg.ShowDialog();


            // if (result == true)
            // {
                if (_changedFilePath.Length > 0)
                {
                    string newXPSDocumentName = string.Concat(Path.GetDirectoryName(_changedFilePath), "\\",
                                                              Path.GetFileNameWithoutExtension(_changedFilePath), ".xps");

                    

                    _viewModel.Document = ConvertWordDocToXPSDoc(_changedFilePath, newXPSDocumentName)
                       .GetFixedDocumentSequence();
                }
            // }
        }

        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            // string docHash = string.Empty;
            // string xpsHash = string.Empty;
            //
            // using (var md5 = MD5.Create())
            // {
            //     using (var stream = File.OpenRead(wordDocName))
            //     {
            //         byte[] hashBytes = md5.ComputeHash(stream);
            //         docHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            //     }
            //
            //     using (var stream = File.OpenRead(xpsDocName))
            //     {
            //         byte[] hashBytes = md5.ComputeHash(stream);
            //         xpsHash = BitConverter.ToString(hashBytes).Replace("-", "".ToLowerInvariant());
            //     }
            // }
            
            if (!File.Exists(xpsDocName))
            {
                var document = new Document(wordDocName);
                document.SaveToFile(xpsDocName, FileFormat.XPS);
                
                if(File.Exists(_changedFilePath))
                    File.Delete(_changedFilePath);
            }

            var xpsDoc = new XpsDocument(xpsDocName, FileAccess.Read);
            
            return xpsDoc;

        }
    }
}