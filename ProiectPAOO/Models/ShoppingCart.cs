﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAOO.Models
{
    internal class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int InstrumentId { get; set; }
        public int Quantity { get; set; }
    }
}
