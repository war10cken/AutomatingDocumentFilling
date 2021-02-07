using Microsoft.EntityFrameworkCore;

namespace AutomatingDocumentFilling.EntityFramework
{
    public class AutomatingDocumentFillingDbContext : DbContext
    {
        public AutomatingDocumentFillingDbContext(DbContextOptions options) : base(options) { }
    }
}