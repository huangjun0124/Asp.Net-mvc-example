using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JunsWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public ICollection<Student> Students { get; set; }

        public string TeacherName { get; set; }
    }

    public class EFDbSet : DbContext
    {
        public EFDbSet():base("name=dbconnection")
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}