using System.Windows;

namespace WpfApplication1.Views
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