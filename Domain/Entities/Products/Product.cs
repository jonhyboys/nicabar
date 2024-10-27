using System.ComponentModel.DataAnnotations;

namespace Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid Category { get; set; }
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Display(Name="Descripción")]
        public string? Description { get; set; }
        public Guid Presentation { get; set; }
        public Guid Measure { get; set; }
        [Display(Name="Costo")]
        public decimal Cost { get; set; }
        [Display(Name="Precio")]
        public decimal Price { get; set; }
        [Display(Name="Cantidad")]
        public int Quantity { get; set; }
    }
}
