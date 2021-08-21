using CodeFirstEF.Entity;
using System.Data.Entity;

namespace CodeFirstEF.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionName) : base(connectionName) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}