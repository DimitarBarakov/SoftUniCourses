using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using TeisterMask.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
//⦁	Id - integer, Primary Key
//⦁	Name - text with length[2, 40] (required)
//⦁	OpenDate - date and time(required)
//⦁	DueDate - date and time(can be null)
//⦁	Tasks - collection of type Task
