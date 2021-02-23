using System;
using System.Collections.Generic;
using Project0.Data;

using Project0.Customers;

namespace Project0.UI
{
    public class Program
    {
        public static void Main()
        {
            using var dependencies = new Dependencies();
            
            IProject0Repository repository = dependencies.CreateRepository();
            RunUI(repository);
        }

        public static void RunUI(IProject0Repository repository)
        {
            
        }
    }
}
