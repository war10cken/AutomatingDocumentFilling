using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public class Database
    {
        [JsonProperty("CodesOfAcademicDiscipline")]
        public List<CodeOfAcademicDiscipline> CodesOfAcademicDiscipline { get; set; }

        [JsonProperty("FormsOfEducation")]
        public List<string> FormsOfEducation { get; set; }

        [JsonProperty("PlacesOfDisciplineInStructure")]
        public List<string> PlacesOfDisciplineInStructure { get; set; }

        [JsonProperty("CertificationForms")]
        public List<string> CertificationForms { get; set; }

        [JsonProperty("Cycles")]
        public List<string> Cycles { get; set; }

        [JsonProperty("Qualifications")]
        public List<Qualification> Qualifications { get; set; }

        public async ValueTask<T> GetValue<T>(string propertyName)
            where T : class
        {
            Database database = await GetDatabase();

            var property = database?.GetType().GetProperty(propertyName);

            if (property is null)
            {
                property = typeof(CodeOfAcademicDiscipline).GetProperty(propertyName);

                if (property is null)
                {
                    property = typeof(Specialty).GetProperty(propertyName);
                }
            }

            return property?.GetValue(database) as T;
        }

        public static async ValueTask<Database> GetDatabase()
        {
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Database database = await System.Text.Json.JsonSerializer.DeserializeAsync<Database>(stream);

            return database;
        }
    }
}