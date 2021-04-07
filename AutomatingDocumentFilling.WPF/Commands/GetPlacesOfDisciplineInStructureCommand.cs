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
    public class GetPlacesOfDisciplineInStructureCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;

        public GetPlacesOfDisciplineInStructureCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            // Attributes attributes = new Attributes();
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Database database = await JsonSerializer.DeserializeAsync<Database>(stream);

            //var p = attributes.GetType().GetProperty("CodesOfAcademicDiscipline");
            //var ps = attributes.GetType().GetProperties();

            //object obj;

            //obj = await attributes.GetValue("Skills");

            _homeViewModel.PlacesOfDisciplineInStructure = database.PlacesOfDisciplineInStructure;
        }
    }
}