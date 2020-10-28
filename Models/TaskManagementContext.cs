using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskManagement.Models
{
    public class TaskManagementContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
    }

    public class TaskManagementDbInitializer : DropCreateDatabaseAlways<TaskManagementContext>
    {
        protected override void Seed(TaskManagementContext db)
        {
            db.Projects.Add(new Project
            {
                name = "Laborator 1",
                description = "Creati prima aplicatie ASP.NET Core"
            });
            db.Projects.Add(new Project
            {
                name = "Laborator 2",
                description = "Creati a doua aplicatie ASP.NET Core"
            });
            db.Projects.Add(new Project
            {
                name = "Laborator 3",
                description = "Creati a tria aplicatie ASP.NET Core"
            });

            db.Priorities.Add(new Priority
            {
                name = "High"
            });
            db.Priorities.Add(new Priority
            {
                name = "Medium"
            });
            db.Priorities.Add(new Priority
            {
                name = "Low"
            });


            db.TaskStatuses.Add(new TaskStatus
            {
                name = "TO DO"
            });
            db.TaskStatuses.Add(new TaskStatus
            {
                name = "IN PROGRESS"
            });
            db.TaskStatuses.Add(new TaskStatus
            {
                name = "TESTING"
            });
            db.TaskStatuses.Add(new TaskStatus
            {
                name = "REVIEW"
            });
            db.TaskStatuses.Add(new TaskStatus
            {
                name = "COMPLETED"
            });
            db.TaskStatuses.Add(new TaskStatus
            {
                name = "DONE"
            });

            base.Seed(db);
        }
    }
}