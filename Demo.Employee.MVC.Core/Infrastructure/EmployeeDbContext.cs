using Demo.Employee.MVC.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Demo.Employee.MVC.Core.Infrastructure
{
    public class EmployeeDbContext : DbContext
    {
        private readonly string connectionString;

        //public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        //  : base(options)
        //{
        //}       

        public EmployeeDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual DbSet<EmployeeEntity> EmployeeEnties { get; set; }

        public virtual DbSet<JobProfileEntity> JobProfileEnties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobProfileEntity>().HasData(new JobProfileEntity { JobProfileId = (int)JobProfileEnum.Director, JobProfileName = JobProfileEnum.Director.ToString() },
                new JobProfileEntity { JobProfileId = (int)JobProfileEnum.Manager, JobProfileName = JobProfileEnum.Manager.ToString() },
                new JobProfileEntity { JobProfileId = (int)JobProfileEnum.Trainee, JobProfileName = JobProfileEnum.Trainee.ToString() }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString);
            }
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableServiceProviderCaching();
        }
    }
}
