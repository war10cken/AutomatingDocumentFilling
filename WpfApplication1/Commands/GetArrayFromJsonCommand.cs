using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WpfApplication1.Models;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Commands
{
    public class GetArrayFromJsonCommand : AsyncCommandBase
    {
        private Database _database;

        private readonly HomeViewModel _homeViewModel;
        private readonly string _propertyName;

        public GetArrayFromJsonCommand(string propertyName, HomeViewModel homeViewModel)
        {
            _propertyName = propertyName;
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.WhenAll(GetArray(_propertyName));
        }

        private async Task GetArray(string propertyName)
        {
            _database = await Database.GetDatabase();

            var homeViewModelProperty = _homeViewModel.GetType().GetProperty(propertyName);

            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            var property = await _database.GetValue(propertyName);

            homeViewModelProperty?.SetValue(_homeViewModel, property.ToList());
        }
    }
}