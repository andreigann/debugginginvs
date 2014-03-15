using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace IasiDevDemo.Infrastructure
{
    public class CustomerRepository
    {
        public void ChangeName(string newName)
        {
            Trace.WriteLine("Changing name to " + newName);
        }
    }
}