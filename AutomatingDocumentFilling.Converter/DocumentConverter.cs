using System.IO;
using System.Reflection;
using System.Windows.Xps.Packaging;
using Microsoft.Office.Interop.Word;

namespace AutomatingDocumentFilling.Converter
{
    public static class DocumentConverter
    {
        public static void Convert(string inputFilename, string outputFilename, WdSaveFormat wdSaveFormat)
        {
            _Application application = new Application
            {
                Visible = false
            };

            object oMissing = Missing.Value;
            object isVisible = true;
            object readOnly = true;
            object oInput = inputFilename;
            object oOutput = outputFilename;
            object oFormat = wdSaveFormat;

            _Document document = application.Documents.Open(ref oInput, ref oMissing,
                                                            ref readOnly, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref isVisible,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing);

            document.Activate();

            document.SaveAs(ref oOutput, ref oFormat,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing);

            application.Quit(ref oMissing, ref oMissing, ref oMissing);
        }
        
        public static XpsDocument ConvertToXps(string inputFilename, string outputFilename, WdSaveFormat wdSaveFormat = WdSaveFormat.wdFormatXPS)
        {
            _Application application = new Application
            {
                Visible = false
            };

            object oMissing = Missing.Value;
            object isVisible = true;
            object readOnly = true;
            object oInput = inputFilename;
            object oOutput = outputFilename;
            object oFormat = wdSaveFormat;

            _Document document = application.Documents.Open(ref oInput, ref oMissing,
                                                            ref readOnly, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref isVisible,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing);

            document.Activate();

            document.SaveAs(ref oOutput, ref oFormat,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing);

            application.Quit(ref oMissing, ref oMissing, ref oMissing);

            return new XpsDocument(outputFilename, FileAccess.Read);
        }

        public static void ConvertToPdf(string inputFilename, string outputFilename, WdSaveFormat wdSaveFormat = WdSaveFormat.wdFormatPDF)
        {
            _Application application = new Application
            {
                Visible = false
            };

            object oMissing = Missing.Value;
            object isVisible = true;
            object readOnly = true;
            object oInput = inputFilename;
            object oOutput = outputFilename;
            object oFormat = wdSaveFormat;

            _Document document = application.Documents.Open(ref oInput, ref oMissing,
                                                            ref readOnly, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref isVisible,
                                                            ref oMissing, ref oMissing,
                                                            ref oMissing, ref oMissing);

            document.Activate();

            document.SaveAs(ref oOutput, ref oFormat,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing);

            application.Quit(ref oMissing, ref oMissing, ref oMissing);
        }
    }
}