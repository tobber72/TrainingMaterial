using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AutoGenStoredProcs.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        // AutoGenStoredProcs.SchoolDBContext schoolContext = new AutoGenStoredProcs.SchoolDBContext();

        [TestMethod]
        public void CreateSchoolDB()
        {
            SchoolDBContext conn = new SchoolDBContext();
            conn.Student_Detail.Add(new Student_Details { StudentName = "Test", Address = "some address", Course = "some course" });
            conn.SaveChanges();
        }

        [TestMethod]
        public void CreateBlogDB()
        {
            BlogDBContext conn = new BlogDBContext();
            conn.Blog_Detail.Add(new Blog {Name ="test blog"   });
            conn.SaveChanges();
        }


    }
}
