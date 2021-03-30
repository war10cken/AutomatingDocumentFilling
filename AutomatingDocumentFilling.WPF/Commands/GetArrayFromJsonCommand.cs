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
    public class GetArrayFromJsonCommand : ICommand
    {
        private readonly string _propertyName;
        private List<string> _values;

        public GetArrayFromJsonCommand(string propertyName, ref List<string> values)
        {
            _propertyName = propertyName;
            _values = values;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _values = JsonSerializer.Deserialize<List<string>>(_propertyName);
        }
    }

    //public class GetArrayFromJsonCommand : AsyncCommandBase
    //{
    //    private readonly HomeViewModel _homeViewModel;
    //    private readonly string _propertyName;

    //    public GetArrayFromJsonCommand(HomeViewModel homeViewModel, string propertyName)
    //    {
    //        _homeViewModel = homeViewModel;
    //        _propertyName = propertyName;
    //    }

    //    public override Task ExecuteAsync(object parameter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private async Task GetArray()
    //    {
    //        PropertyInfo[] propertyInfos = typeof(Attributes).GetProperties(BindingFlags.Public);

    //        using FileStream stream = File.Open("values.json", FileMode.OpenOrCreate);
    //        Attributes attributes = await JsonSerializer.DeserializeAsync<Attributes>(stream);

    //        for (int i = 0; i < propertyInfos.Length; i++)
    //        {
    //            if(propertyInfos[i].Name == _propertyName)
    //                propertyInfos[i].set
    //        }
    //    }
    //}
}