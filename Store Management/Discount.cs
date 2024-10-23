using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management
{
    public struct Discount
    {
     public double Percentage { get; private set; }
        public Discount( double percentage)
        {
         Percentage = percentage;
        }

    }
}
