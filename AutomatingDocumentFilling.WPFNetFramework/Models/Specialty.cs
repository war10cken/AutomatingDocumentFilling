using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public class Specialty
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SkillNames")]
        public List<string> SkillNames { get; set; }

        [JsonProperty("KnowledgeNames")]
        public List<string> KnowledgeNames { get; set; }

        [JsonProperty("GeneralCompetenceNames")]
        public List<string> GeneralCompetenceNames { get; set; }

        [JsonProperty("ProfessionalCompetenceNames")]
        public List<string> ProfessionalCompetenceNames { get; set; }
    }
}