using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding_task.Models {
    public class OrderModel : IValidatableObject {
        [BindNever]
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        public DateTime? OrderDate { get; set; }
        [Required]
        public double? InvoicPrice { get; set; }
        [Required]
        public List<ProductModel?>? Products { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (Products is not null) {
                double total = 0;
                foreach (var p in Products) {
                    if (p.Price.HasValue && p.Quantity.HasValue) total += p.Price.Value * p.Quantity.Value;
                }
                if (total == InvoicPrice) yield return ValidationResult.Success;
                else yield return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order.", new string[] { nameof(InvoicPrice) });
            } else yield break;
        }
    }
}
