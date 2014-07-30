using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace AutoGenStoredProcs
{

    /// <summary>
    /// attempt to autogenerate procedures 
    /// pulled from article - http://www.c-sharpcorner.com/UploadFile/99bb20/code-first-insertupdatedelete-stored-procedure-in-entity-f/
    /// </summary>
    public class Student_Details
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Course { get; set; }
    }

    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
            : base("SchoolDBConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here 
            modelBuilder.Entity<Student_Details>().MapToStoredProcedures();
        }

        public DbSet<Student_Details> Student_Detail { get; set; }



    }

}
