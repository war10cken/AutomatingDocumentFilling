using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class OpenFileCommand : ICommand
    {
        private readonly string _outputFileName;

        public OpenFileCommand(string outputFileName)
        {
            _outputFileName = outputFileName;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _outputFileName != "";
        }

        public void Execute(object parameter)
        {
            if (File.Exists(_outputFileName))
            {
                Application application = new Application()
                {
                    Visible = true
                };

                string path = Path.GetFullPath(_outputFileName);

                Document document = application.Documents.Open(path);
                document.Activate();
            }
        }
    }
}