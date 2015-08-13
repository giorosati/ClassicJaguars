using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassicJaguars.Data.Model
{
    public class Car
    {
        [Key]
        public int ModelId { get; set; }

        [Required]
        public string ModelName { get; set; }

        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public int? UnitsProduced { get; set; }

        [Required]
        public string Description { get; set; }

        public string Synopsis { get; set; }
        public string ImgUrl { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        //virtual lists
        public virtual List<Transaction> Transactions { get; set; }
    }
}