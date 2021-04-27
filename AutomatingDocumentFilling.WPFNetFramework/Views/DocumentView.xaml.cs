using System.Windows;

namespace AutomatingDocumentFilling.WPFNetFramework.Views
{
    public partial class DocumentView : Window
    {
        public DocumentView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}