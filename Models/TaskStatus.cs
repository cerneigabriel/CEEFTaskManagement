using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class TaskStatus
    {
        [Key]
        [DisplayName("TaskStatusID")]
        public int TaskStatusID { get; set; }

        [DisplayName("Status")]
        public string name { get; set; }

        [DisplayName("Tasks")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}