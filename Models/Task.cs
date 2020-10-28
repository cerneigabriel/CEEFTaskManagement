using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskManagement.Models
{
    public class Task
    {
        [Key]
        [DisplayName("TaskID")]
        public int TaskID { get; set; }

        [DisplayName("Task")]
        public string name { get; set; }

        [DisplayName("Task Description")]
        public string description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Task StartDate")]
        public DateTime start_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Task DueDate")]
        public DateTime due_date { get; set; }

        [DisplayName("Task Estimated Time")]
        public string estimated_time { get; set; }

        [DisplayName("Task TrackedTime")]
        public string tracked_time { get; set; }



        [DisplayName("CreatedAt")]
        public DateTime created_at { get; set; }

        [DisplayName("UpdatedAt")]
        public DateTime updated_at { get; set; }



        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DisplayName("Project")]
        public virtual Project Project { get; set; }

        [ForeignKey("TaskStatus")]
        public int TaskStatusID { get; set; }
        [DisplayName("TaskStatus")]
        public virtual TaskStatus TaskStatus { get; set; }

        [ForeignKey("Priority")]
        public int PriorityID { get; set; }
        [DisplayName("Priority")]
        public virtual Priority Priority { get; set; }

        [DisplayName("TaskNotes")]
        public virtual ICollection<TaskNote> TaskNotes { get; set; }


        public Task()
        {
            this.created_at = DateTime.UtcNow;
            this.updated_at = DateTime.UtcNow;
        }
    }
}