using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IasiDevDemo.Infrastructure
{
    public class Bll
    {
        public void UpdateCustomer(Customer c)
        {
            var dal = new Dal();
            dal.UpdateCustomer(c);
        }
    }
}