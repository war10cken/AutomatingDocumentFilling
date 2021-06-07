using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class Qualification
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Discription")]
        public string Discription { get; set; }
    }
}