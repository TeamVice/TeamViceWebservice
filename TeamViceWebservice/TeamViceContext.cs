namespace TeamViceWebservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TeamViceContext : DbContext
    {
        public TeamViceContext()
            : base("name=TeamViceContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Appartment> Appartment { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepZipCode> DepZipCode { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appartment>()
                .Property(e => e.AppartmentOwner)
                .IsUnicode(false);

            modelBuilder.Entity<Appartment>()
                .HasMany(e => e.Assignment)
                .WithRequired(e => e.Appartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.AssignTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.AssignText)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.AssignComment)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Appartment)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Assignment)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DepZipCode>()
                .Property(e => e.DepCity)
                .IsUnicode(false);

            modelBuilder.Entity<DepZipCode>()
                .HasMany(e => e.Department)
                .WithRequired(e => e.DepZipCode1)
                .HasForeignKey(e => e.DepZipCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Assignment)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);
        }
    }
}
