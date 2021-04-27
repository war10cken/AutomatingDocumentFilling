using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public class Database
    {
        public List<string> CodesOfAcademicDiscipline { get; set; }
        public List<string> Specialties { get; set; }
        public List<string> FormsOfEducation { get; set; }
        public List<string> PlacesOfDisciplineInStructure { get; set; }
        public List<string> SkillNames { get; set; }
        public List<string> KnowledgeNames { get; set; }
        public List<string> GeneralCompetenceNames { get; set; }

        public async Task<IEnumerable<string>> GetValue(string propertyName)
        {
            Database database = await GetDatabase();

            var property = database?.GetType().GetProperty(propertyName);

            return property?.GetValue(database) as List<string>;
        }

        public static async Task<Database> GetDatabase()
        {
            using FileStream stream = File.Open("values.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Database database = await JsonSerializer.DeserializeAsync<Database>(stream);

            return database;
        }
    }
}