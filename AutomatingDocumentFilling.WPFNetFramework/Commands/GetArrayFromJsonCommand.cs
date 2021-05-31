using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutomatingDocumentFilling.WPFNetFramework.Models;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class GetArrayFromJsonCommand<TViewModel, TPropertyType> : AsyncCommandBase
        where TViewModel : ViewModelBase
        where TPropertyType : class
    {
        private Database _database;

        private readonly TViewModel _viewModel;
        private readonly string _propertyName;

        public GetArrayFromJsonCommand(string propertyName, TViewModel viewModel)
        {
            _propertyName = propertyName;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await GetArray(_propertyName);
        }

        private async ValueTask GetArray(string propertyName)
        {
            string propertyNameWithoutSecond = "";
            _database = await Database.GetDatabase();

            if (propertyName.Contains("Second"))
            {
                propertyNameWithoutSecond = propertyName.Replace("Second", "");
            }

            var viewModelProperty = _viewModel.GetType().GetProperty(propertyName);

            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            var property =
                await _database.GetValue<TPropertyType>(propertyNameWithoutSecond == "" ? propertyName : propertyNameWithoutSecond);

            viewModelProperty?.SetValue(_viewModel, property);
        }
    }
}