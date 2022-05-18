using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentDTO : BaseDTO
    {
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
