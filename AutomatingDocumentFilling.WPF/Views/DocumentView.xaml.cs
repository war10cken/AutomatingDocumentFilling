using System.Windows;

namespace AutomatingDocumentFilling.WPF.Views
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