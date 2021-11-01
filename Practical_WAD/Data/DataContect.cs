using Practical_WAD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_WAD.Data
{
    public class DataContect: DbContext
    {
        public DataContect() : base("Practical_WAD") { }
        public DbSet<Subject> Subjects { get; set; } 
        public DbSet<Classroom> Classrooms { get; set; } 
        public DbSet<Falculty> Falculties { get; set; } 
        public DbSet<Status> Statuses { get; set; } 
        public DbSet<Exam> Exams { get; set; } 

    }
}