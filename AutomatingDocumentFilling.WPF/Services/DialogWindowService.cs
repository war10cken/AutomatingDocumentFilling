using System.Windows;
using System.Windows.Controls;

namespace AutomatingDocumentFilling.WPF.Services
{
    public class DialogWindowService<T> : IDialogWindowService<T> where T : Window
    {
        private readonly T _window;

        public DialogWindowService(T window)
        {
            _window = window;
        }

        public void Show()
        {
            _window.Show();
        }

        public void ShowDialog()
        {
            _window.ShowDialog();
        }
    }
}