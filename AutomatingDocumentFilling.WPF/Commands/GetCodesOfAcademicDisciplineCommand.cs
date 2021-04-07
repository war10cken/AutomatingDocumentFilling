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

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class GetCodesOfAcademicDisciplineCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;

        public GetCodesOfAcademicDisciplineCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.WhenAll(GetArray());
        }

        private async Task GetArray()
        {
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Database database = await JsonSerializer.DeserializeAsync<Database>(stream);

            // var p = attributes.GetType().GetProperty("CodesOfAcademicDiscipline");
            // var ps = attributes.GetType().GetProperties();
            //
            // object obj;
            //
            // foreach (PropertyInfo propertyInfo in ps)
            // {
            //     obj = propertyInfo.GetValue(attributes);
            // }

            //var f = p.GetValue(p);

            _homeViewModel.CodesOfAcademicDiscipline = database.CodesOfAcademicDiscipline;
        }
    }
}