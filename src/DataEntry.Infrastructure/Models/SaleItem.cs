using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }
        public int SaleId { get; set; }
        public Sale? Sale { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalPrice { get; set; }
    }
}
