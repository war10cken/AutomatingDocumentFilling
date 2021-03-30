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
    public class GetSpecialtiesCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;

        public GetSpecialtiesCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.WhenAll(GetSpecialties());
        }

        private async Task GetSpecialties()
        {
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Attributes attributes = await JsonSerializer.DeserializeAsync<Attributes>(stream);

            _homeViewModel.Specialties = attributes.Specialties;
        }
    }
}