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
using Spire.Doc;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class OpenDocumentCommand : ICommand
    {
        private readonly DocumentViewModel _viewModel;
        private readonly string _firstPart;
        private readonly string _secondPart;
        private readonly string _thirdPart;
        private readonly string _fourthPart;

        public OpenDocumentCommand(DocumentViewModel viewModel, string firstPart,
                                   string secondPart, string thirdPart, string fourthPart)
        {
            _viewModel = viewModel;
            _firstPart = firstPart;
            _secondPart = secondPart;
            _thirdPart = thirdPart;
            _fourthPart = fourthPart;
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

            if (_firstPart.Length > 0 && _secondPart.Length > 0 &&
                _thirdPart.Length > 0 && _thirdPart.Length > 0)
            {
                string newXPSFirstPartDocumentName = string.Concat(Path.GetDirectoryName(_firstPart), "\\",
                                                          Path.GetFileNameWithoutExtension(_firstPart), ".xps");
                string newXPSSecondPartDocumentName = string.Concat(Path.GetDirectoryName(_secondPart), "\\",
                                                                   Path.GetFileNameWithoutExtension(_secondPart), ".xps");
                string newXPSThirdPartDocumentName = string.Concat(Path.GetDirectoryName(_thirdPart), "\\",
                                                                   Path.GetFileNameWithoutExtension(_thirdPart), ".xps");
                string newXPSFourthPartDocumentName = string.Concat(Path.GetDirectoryName(_fourthPart), "\\",
                                                                   Path.GetFileNameWithoutExtension(_fourthPart), ".xps");

                CreateXpsDocument("doc-c1c.docx", newXPSFirstPartDocumentName);
                CreateXpsDocument("doc-c2c.docx", newXPSSecondPartDocumentName);
                CreateXpsDocument("doc-c3c.docx", newXPSThirdPartDocumentName);
                CreateXpsDocument("doc-c4c.docx", newXPSFourthPartDocumentName);

                var xpsDocs = new List<XpsDocument>
                {
                    new XpsDocument(newXPSFirstPartDocumentName, FileAccess.Read),
                    new XpsDocument(newXPSSecondPartDocumentName, FileAccess.Read),
                    new XpsDocument(newXPSThirdPartDocumentName, FileAccess.Read),
                    new XpsDocument(newXPSFourthPartDocumentName, FileAccess.Read)
                };

                var xpsDocument = MergeXpsDocument("doc.xps", xpsDocs);

                _viewModel.Document = xpsDocument.GetFixedDocumentSequence();
                xpsDocument.Close();

                // xpsDocs.ForEach(d => d.Close());

                //if (File.Exists(newXPSFirstPartDocumentName) && File.Exists(newXPSSecondPartDocumentName)
                //    && File.Exists(newXPSThirdPartDocumentName) && File.Exists(newXPSFourthPartDocumentName))
                //{
                //    File.Delete(newXPSFirstPartDocumentName);
                //    File.Delete(newXPSSecondPartDocumentName);
                //    File.Delete(newXPSThirdPartDocumentName);
                //    File.Delete(newXPSFourthPartDocumentName);
                //}
            }
        }

        private void CreateXpsDocument(string documentName, string xpsDocumentName)
        {
            Document document = new Document(documentName);
            document.SaveToFile(xpsDocumentName, FileFormat.XPS);
        }

        // private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        // {
        //     // string docHash = string.Empty;
        //     // string xpsHash = string.Empty;
        //     //
        //     // using (var md5 = MD5.Create())
        //     // {
        //     //     using (var stream = File.OpenRead(wordDocName))
        //     //     {
        //     //         byte[] hashBytes = md5.ComputeHash(stream);
        //     //         docHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        //     //     }
        //     //
        //     //     using (var stream = File.OpenRead(xpsDocName))
        //     //     {
        //     //         byte[] hashBytes = md5.ComputeHash(stream);
        //     //         xpsHash = BitConverter.ToString(hashBytes).Replace("-", "".ToLowerInvariant());
        //     //     }
        //     // }
        //     File.Delete(xpsDocName);
        //
        //     // if (!File.Exists(xpsDocName))
        //     // {
        //     //     var document = new Document(wordDocName);
        //     //     document.SaveToFile(xpsDocName, FileFormat.XPS);
        //     //
        //     //     //if (File.Exists(_changedFilePath))
        //     //     //    File.Delete(_changedFilePath);
        //     // }
        //
        //
        //
        //
        //
        //     return xpsDoc;
        // }

        private XpsDocument MergeXpsDocument(string newFile, List<XpsDocument> sourceDocuments)
        {
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }

            XpsDocument xpsDocument = new XpsDocument(newFile, FileAccess.ReadWrite);
            XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            FixedDocumentSequence fixedDocumentSequence = new FixedDocumentSequence();

            foreach (XpsDocument doc in sourceDocuments)
            {
                FixedDocumentSequence sourceSequence = doc.GetFixedDocumentSequence();

                foreach (DocumentReference dr in sourceSequence.References)
                {
                    DocumentReference newDocumentReference = new DocumentReference
                    {
                        Source = dr.Source
                    };
                    (newDocumentReference as IUriContext).BaseUri = (dr as IUriContext).BaseUri;
                    FixedDocument fd = newDocumentReference.GetDocument(true);
                    newDocumentReference.SetDocument(fd);
                    fixedDocumentSequence.References.Add(newDocumentReference);
                }
            }
            xpsDocumentWriter.Write(fixedDocumentSequence);

            return xpsDocument;
        }

        public event EventHandler? CanExecuteChanged;
    }
}