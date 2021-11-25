using System;

namespace Store.Ind.Domain.Dtos
{
    public class ProductDto : CsvReportBaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }

        public string BrandName { get; set; }
    }
}
