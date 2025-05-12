using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAOO.Models
{
    internal class PurchaseLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int InstrumentId { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
    }
}
