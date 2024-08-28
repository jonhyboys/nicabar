using Application.Sales;
using Domain.Tables;

namespace Presentation.Models
{
    public class SaleViewModel
    {
        public IEnumerable<Table> Tables { get; set; }
        public SaleAddModel SaleModel { get; set; }
    }
}
