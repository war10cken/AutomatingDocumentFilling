using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPFNetFramework.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            var s = new AdminPanelViewModel("valuescopy.json");
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void ComboBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            comboBox.IsDropDownOpen = true;
        }
    }
}