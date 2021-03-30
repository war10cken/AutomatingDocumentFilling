using AutomatingDocumentFilling.WPF.Models;
using AutomatingDocumentFilling.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class GetFormsOfEducationCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;

        public GetFormsOfEducationCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.WhenAll(GetFormsOfEducation());
        }

        private async Task GetFormsOfEducation()
        {
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Attributes attributes = await JsonSerializer.DeserializeAsync<Attributes>(stream);

            _homeViewModel.FormsOfEducation = attributes.FormsOfEducation;
        }
    }
}