using System;
using BocesModule.Shared;
using Microsoft.EntityFrameworkCore;

namespace BocesModule.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Employee> Employees { get; set; }

        //public DbSet<Country> Countries { get; set; }

        //public DbSet<JobCategory> JobCategories { get; set; }

        public DbSet<CoSerGroup> CoSerGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////seed categories
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Belgium" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Germany" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Netherlands" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "USA" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Japan" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 6, Name = "China" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 7, Name = "UK" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 8, Name = "France" });
            //modelBuilder.Entity<Country>().HasData(new Country { CountryId = 9, Name = "Brazil" });

            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 1, JobCategoryName = "Pie research"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 2, JobCategoryName = "Sales"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 3, JobCategoryName = "Management"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 4, JobCategoryName = "Store staff"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 5, JobCategoryName = "Finance"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 6, JobCategoryName = "QA"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 7, JobCategoryName = "IT"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 8, JobCategoryName = "Cleaning"});
            //modelBuilder.Entity<JobCategory>().HasData(new JobCategory(){JobCategoryId = 9, JobCategoryName = "Bakery"});

            modelBuilder.Entity<CoSerGroup>().HasData(new CoSerGroup() { CoSerGroupId = 1, CoSerGroupCode = "CoSerGroup1", CoSerGroupName = "CoSer Group 1" });
            modelBuilder.Entity<CoSerGroup>().HasData(new CoSerGroup() { CoSerGroupId = 2, CoSerGroupCode = "CoSerGroup2", CoSerGroupName = "CoSer Group 2" });
            modelBuilder.Entity<CoSerGroup>().HasData(new CoSerGroup() { CoSerGroupId = 3, CoSerGroupCode = "CoSerGroup3", CoSerGroupName = "CoSer Group 3" });

            //modelBuilder.Entity<Employee>().HasData(new Employee
            //{
            //    EmployeeId = 1,
            //    CountryId = 1,
            //    MaritalStatus = MaritalStatus.Single,
            //    BirthDate = new DateTime(1979, 1, 16),
            //    City = "Sacramento",
            //    Email = "soumya@wincap.com",
            //    FirstName = "Soumya",
            //    LastName = "Sengupta",
            //    Gender = Gender.Male,
            //    PhoneNumber = "324777888773",
            //    Smoker = true,
            //    Street = "Main St.",
            //    Zip = "95835",
            //    JobCategoryId = 1,
            //    Comment = "No comments",
            //    ExitDate = null,
            //    JoinedDate = new DateTime(2015, 3, 1),
            //    Latitude = 50.8503, 
            //    Longitude = 4.3517
            //});
        }
    }
}
