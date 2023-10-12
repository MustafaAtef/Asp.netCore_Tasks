using System.ComponentModel.DataAnnotations;

namespace ModelBinding_task.Models {
    public class ProductModel {
        [Required]
        public int? ProductCode { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double? Price { get; set; }
    }
}
