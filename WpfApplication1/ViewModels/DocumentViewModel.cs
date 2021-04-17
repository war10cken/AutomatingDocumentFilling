using System.Windows.Documents;
using System.Windows.Input;

namespace WpfApplication1.ViewModels
{
    public class DocumentViewModel : ViewModelBase
    {

        private IDocumentPaginatorSource _document;

        public IDocumentPaginatorSource Document
        {
            get => _document;
            set
            {
                _document = value;
                OnPropertyChanged(nameof(Document));
            }
        }

        public ICommand OpenDocumentCommand { get; set; }

    }
}