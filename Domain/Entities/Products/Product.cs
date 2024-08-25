using System.ComponentModel.DataAnnotations;

namespace Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Display(Name="Descripción")]
        public string? Description { get; set; }
        [Display(Name="Presentación")]
        public string? Presentation { get; set; }
        public Guid Measure { get; set; }
        [Display(Name="Costo")]
        public decimal Cost { get; set; }
        [Display(Name="Precio")]
        public decimal Price { get; set; }
        [Display(Name="Cantidad")]
        public int Quantity { get; set; }
    }
}
