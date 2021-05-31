using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public class CodeOfAcademicDiscipline
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Specialties")]
        public List<Specialty> Specialties { get; set; }
    }
}