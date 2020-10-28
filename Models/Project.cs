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
    public class Project
    {
        [Key]
        [DisplayName("ProjectID")]
        public int ProjectID { get; set; }

        [DisplayName("Project")]
        public string name { get; set; }

        [DisplayName("Project Description")]
        public string description { get; set; }

        [DisplayName("CreatedAt")]
        public DateTime created_at { get; set; }

        [DisplayName("UpdatedAt")]
        public DateTime updated_at { get; set; }

        [DisplayName("Tasks")]
        public virtual ICollection<Task> Tasks { get; set; }

        public Project()
        {
            this.created_at = DateTime.UtcNow;
            this.updated_at = DateTime.UtcNow;
        }
    }
}