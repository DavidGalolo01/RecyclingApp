using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecyclingApp.Models
{
    public class RecyclableType
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Type must be less than 100 characters.")]
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public decimal MinKg { get; set; }
        public decimal MaxKg { get; set; }
    }
}