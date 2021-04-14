using AutomatingDocumentFilling.WPF.Models;
using AutomatingDocumentFilling.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPF.Commands
{
    // public class GetArrayFromJsonCommand : ICommand
    // {
    //     private readonly string _propertyName;
    //     private IEnumerable<string> _values;
    //     private Database _database;
    //
    //     public GetArrayFromJsonCommand(string propertyName, ref List<string> values)
    //     {
    //         _propertyName = propertyName;
    //         _values = values;
    //         _database = new Database(ref _database);
    //     }
    //
    //     public event EventHandler CanExecuteChanged;
    //
    //     public bool CanExecute(object parameter)
    //     {
    //         return true;
    //     }
    //
    //     public void Execute(object parameter)
    //     {
    //         _values = JsonSerializer.Deserialize<List<string>>(_propertyName);
    //     }
    //
    //     private async Task GetArray(string propertyName)
    //     {
    //         using FileStream stream = File.Open("values.json", FileMode.OpenOrCreate);
    //         var property = await _database.GetValue(propertyName);
    //
    //         _values = property;
    //     }
    // }

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