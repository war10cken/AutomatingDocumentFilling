using AutomatingDocumentFilling.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomatingDocumentFilling.EntityFramework
{
    public class AutomatingDocumentFillingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AutomatingDocumentFillingDbContext(DbContextOptions options) : base(options) { }
    }
}