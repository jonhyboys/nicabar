using System.ComponentModel.DataAnnotations;

namespace Domain.Sales
{
    public class Sale
    {
        public Guid Id { get; set; }
        [Display(Name ="Mesa")]
        public int Table { get; set; }
        [Display(Name = "Producto")]
        public Guid Product { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Nota")]
        public string? Note { get; set; }
    }
}
