using System.Collections.Generic;

namespace WpfApplication1.Models
{
    public class Theme
    {
        public string Name { get; set; }
        public List<EducationMaterial> EducationMaterials { get; set; }
        public List<PracticalTrainingTopics> PracticalTrainingTopicsList { get; set; }

        public List<string> Codes { get; set; }
    }
}