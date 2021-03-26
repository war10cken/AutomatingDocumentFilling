using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPF.Views
{
    public partial class FirstPageView : UserControl
    {
        public FirstPageView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".docx";

            dlg.Filter = "Word documents (.docx)|*.docx";

            bool? result = dlg.ShowDialog();


            if (result == true)
            {
                if (dlg.FileName.Length > 0)
                {
                    string newDocumentName = string.Concat(Path.GetDirectoryName(dlg.FileName), "\\",
                                                              Path.GetFileNameWithoutExtension(dlg.FileName), ".docx");

                    using (var document = DocX.Load(newDocumentName))
                    {
                        if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                        {
                            document.ReplaceText("<code>", TextBoxName.Text, false, RegexOptions.IgnoreCase);
                            document.Save();
                        }
                    }
                }          
            }
        }
    }
}