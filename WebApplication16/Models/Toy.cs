using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16.Models
{
    public class Toy
    {
        public int toyId;

        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column("Toy")]
        [StringLength(50)]
        public string Toy1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? age { get; set; }
    }
}
