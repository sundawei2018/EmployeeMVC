namespace EmployeeTaskMVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ETask> ETasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
