using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Infrastructure.Models
{
    public class TaskModel
    {
        public int ID { get; set; }

        [MaxLength(100)]
        [Required]
        public string title { get; set; }

        [MaxLength(1200)]
        [Required]
        public string text { get; set; }
    }
}
