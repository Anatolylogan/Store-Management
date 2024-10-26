using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management
{
    public struct Discount
    {
     public double Percentage { get; set; }
        public Discount( double percentage)
        {
         Percentage = percentage;
        }
        public double CalculateDiscountAmount(double price)
        {
            return price * (Percentage / 100);
        }
    }
}
