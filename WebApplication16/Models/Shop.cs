using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16.Models
{
    public class Shop
    {
        public object toy;
        internal int shopId;

        [StringLength(10)]
        public string id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Toys { get; set; }

        [StringLength(50)]
        public string Categories { get; set; }
    }
}
