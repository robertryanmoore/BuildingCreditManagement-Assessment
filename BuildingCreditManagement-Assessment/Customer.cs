using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingCreditManagement_Assessment
{
    internal class Customer
    {
        public int CustomerId {  get; set; }
        public string? Name { get; set; }
        public float PaymentHistory { get; set; }//(percentage of payments made on time, 0 to 100)
        public float CreditUtilization { get; set; } //(percentage of credit limit used, 0 to 100)
        public int AgeOfCreditHistory { get; set; }
    }
}
