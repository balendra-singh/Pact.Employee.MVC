using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Employee.MVC.Core.Infrastructure
{
    [Table("jobprofile")]
    public partial class JobProfileEntity
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int JobProfileId { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string JobProfileName { get; set; }
    }
}
