using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskManagement.Models
{
    public class TaskNote
    {
        [Key]
        [DisplayName("TaskNoteID")]
        public int TaskNoteID { get; set; }

        [DisplayName("Note")]
        public string note { get; set; }


        [DisplayName("CreatedAt")]
        public DateTime created_at { get; set; }

        [DisplayName("UpdatedAt")]
        public DateTime updated_at { get; set; }


        [ForeignKey("Task")]
        public int TaskID { get; set; }
        [DisplayName("Task")]
        public virtual Task Task { get; set; }

        public TaskNote ()
        {
            this.created_at = DateTime.UtcNow;
            this.updated_at = DateTime.UtcNow;
        }
    }
}