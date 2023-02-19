using BET.Models;
using Microsoft.EntityFrameworkCore;

namespace BET.Infrastructure
{
    public class BEDbContext : DbContext
    {
        private readonly string _connectionString = String.Empty;

        public DbSet<Deparment> Deparments { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<DeparmentEmployee> DeparmentEmployees { get; set; } = null!;

        public BEDbContext(DbContextOptions<BEDbContext> options) : base(options) { }

        public BEDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != string.Empty)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BEMapping(modelBuilder);
        }



        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            //GenerateOnUpdateForEmployee();

            return base.SaveChanges(true);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //GenerateOnUpdateForEmployee();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        //private void GenerateOnUpdateForEmployee()
        //{
        //    var entityEntries = ChangeTracker.Entries<Employee>().Where(x => x.State == EntityState.Added).ToList();

        //    foreach (var entityEntry in entityEntries)
        //    {
        //        if (entityEntry.Property("Code").CurrentValue == null)
        //        {
        //            entityEntry.Property("Code").CurrentValue = $"Emp - {entityEntry.Property("Id").CurrentValue}";
        //        }
        //    }
        //}

        private void BEMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deparment>(b =>
            {
                b.ToTable("Deparments");
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.Property(x => x.Code).HasMaxLength(100).IsRequired();
                b.Property(x => x.Name).IsRequired();
                b.HasMany(x => x.DeparmentEmployee).WithOne(x => x.Deparment).HasForeignKey(x => x.DeparmentId);

            });

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees");
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.Property(x => x.Code).HasMaxLength(100);
                b.Property(x => x.Name).IsRequired();
                b.HasMany(x => x.DeparmentEmployee).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
            });

            modelBuilder.Entity<DeparmentEmployee>(b =>
            {
                b.ToTable("DeparmentEmployees");
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.Property(x => x.DeparmentId).IsRequired();
                b.Property(x => x.EmployeeId).IsRequired();
                b.HasOne(x => x.Deparment).WithMany(x => x.DeparmentEmployee).HasForeignKey(x => x.DeparmentId);
                b.HasOne(x => x.Employee).WithMany(x => x.DeparmentEmployee).HasForeignKey(x => x.EmployeeId);
            });
        }
    }
}
