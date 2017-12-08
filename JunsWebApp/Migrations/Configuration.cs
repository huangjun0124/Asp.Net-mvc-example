using System.Collections.Generic;
using JunsWebApp.Models;

namespace JunsWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JunsWebApp.Models.EFDbSet>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "JunsWebApp.Models.EFDbSet";
        }

        protected override void Seed(JunsWebApp.Models.EFDbSet context)
        {
            Student stu = new Student() {Name = "Andrew Peters", Sex = "Male", Age = 23};
            context.Students.AddOrUpdate(
              s=>s.Name,
              stu
            );
            context.Classes.AddOrUpdate(
                c => c.Name,
                new Class()
                {
                    Name = "C1",
                    TeacherName = "Marry",
                    Students = new List<Student>
                    {
                        stu,
                        new Student() { Name = "Wankis Peters", Sex = "FeMale", Age = 12 },
                        new Student() { Name = "Fucker Lucker", Sex = "FeMale", Age = 25 },
                        new Student() { Name = "God EWater", Sex = "Male", Age = 11 },
                        new Student() { Name = "Jun God", Sex = "Male", Age = 11 }
                    }
                },
                new Class()
                {
                    Name = "A2",
                    TeacherName = "Junrry",
                    Students = new List<Student>
                    {
                        new Student() { Name = "Love Maker", Sex = "FeMale", Age = 15 },
                        new Student() { Name = "Sans Doris", Sex = "Male", Age = 13 },
                        new Student() { Name = "Jerry Stark", Sex = "Male", Age = 12 },
                    }
                }
            );

            string[] namePrefixs = new[] {"Cls", "Grade", "Top", "Middle", "Bottom"};
            string[] teacherNames = new []{"Juns","Li","Logan","Hurry","Stark"};
            for (int i = 0; i < 500; i++)
            {
                context.Classes.AddOrUpdate(
                    c => c.Name,
                    new Class()
                    {
                        Name = namePrefixs[i%namePrefixs.Length]+i,
                        TeacherName = teacherNames[i% teacherNames.Length]
                    }
                );
            }
        }
    }
}
