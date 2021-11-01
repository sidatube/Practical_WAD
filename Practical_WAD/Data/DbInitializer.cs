using Practical_WAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_WAD.Data
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContect>
    {
        protected override void Seed(DataContect context)
        {
            var Classrooms = new List<Classroom>
            {
                new Classroom{name="B10"},
                new Classroom{name="B11"},
                new Classroom{name="B12"},
                new Classroom{name="B13"},
                new Classroom{name="B14"},
                new Classroom{name="B15"},
                new Classroom{name="B16"},
            };
            Classrooms.ForEach(s => context.Classrooms.Add(s));
            context.SaveChanges();
            var Falcultys = new List<Falculty>
            {
                new Falculty{name="Jayalakshmi"},
                new Falculty{name="Joun Carter"},
                new Falculty{name="HienPA"},

            };
            Falcultys.ForEach(s => context.Falculties.Add(s));
            context.SaveChanges();
            var Statuses = new List<Status>
            {
                new Status{status="done"},
                new Status{status="on going"},
                new Status{status="up coming"},

            };
            Statuses.ForEach(s => context.Statuses.Add(s));
            context.SaveChanges();
            var Subjects = new List<Subject>
            {
                new Subject{name="Core Java"},
                new Subject{name="Advance Java"},
                new Subject{name="Programming C#"},
          
            };
            Subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();
            
        }
    }
}