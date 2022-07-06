using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Models
{
    public class Sale : Base
    {
        public int InvoiceNumber { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalSale { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal AmountPaid { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime Date { get; set; }
    }
}
