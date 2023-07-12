using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proiectPIU.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer ten 50 char")]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Category { get; set; }

    }
}
