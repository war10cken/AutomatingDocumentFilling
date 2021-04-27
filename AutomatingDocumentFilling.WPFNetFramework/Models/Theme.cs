using System.Collections.Generic;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public class Theme
    {
        public string Name { get; set; }
        public List<EducationMaterial> EducationMaterials { get; set; }
        public List<PracticalTrainingTopics> PracticalTrainingTopicsList { get; set; }

        public List<string> Codes { get; set; }
    }
}