using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace AutomatingDocumentFilling.EntityFramework
{
    public class AutomatingDocumentFillingDbContextFactory : IDesignTimeDbContextFactory<AutomatingDocumentFillingDbContext>
    {
        public AutomatingDocumentFillingDbContext CreateDbContext(string[] args = null!)
        {
            var optionBuilder = new DbContextOptionsBuilder<AutomatingDocumentFillingDbContext>();
            optionBuilder
               .UseSqlServer(@"Server=DESKTOP-PON2VF7\SQLEXPRESS;Database=AutomatingDocumentFilling;Trusted_Connection=True;");

            return new AutomatingDocumentFillingDbContext(optionBuilder.Options);
        }
    }
}