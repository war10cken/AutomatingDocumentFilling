using AutomatingDocumentFilling.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutomatingDocumentFilling.WPF.Models;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class GetSkillsCommand : AsyncCommandBase
    {
        private readonly SkillViewModel _skillViewModel;

        public GetSkillsCommand(SkillViewModel skillViewModel)
        {
            _skillViewModel = skillViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.WhenAll(GetArray());
        }

        private async Task GetArray()
        {
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Database database = await JsonSerializer.DeserializeAsync<Database>(stream);

            _skillViewModel.Skills = database.Skills;
        }
    }
}