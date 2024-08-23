using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecyclingApp.Models
{
    public class RecyclableItem
    {
        public int Id { get; set; }

        [ForeignKey("RecyclableType")]
        public int RecyclableTypeId { get; set; }
        public RecyclableType RecyclableType { get; set; }

        public decimal Weight { get; set; }

        [NotMapped]
        public decimal ComputedRate => RecyclableType != null
            ? Math.Round(RecyclableType.Rate * Weight, 2)
            : 0;

        [StringLength(150, ErrorMessage = "Item Description must be less than 150 characters.")]
        public string ItemDescription { get; set; }
    }

}
