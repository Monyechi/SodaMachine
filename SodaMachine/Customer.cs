using OopSodaMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Random random;
        public Customer customer1 = new Customer();

        public Customer()
        {
            wallet = new Wallet(random);
            DisplayCash(customer1);
        }
        public void DisplayCash(Customer customer)
        {
            double total;

            Console.WriteLine("You have " + customer.wallet.quarters.Count + " quarters.");
            Console.WriteLine("You have " + customer.wallet.dimes.Count + " dimes.");
            Console.WriteLine("You have " + customer.wallet.nickels.Count + " nickels.");
            Console.WriteLine("You have " + customer.wallet.pennies.Count + " pennies.");
            total = customer.wallet.dimes.Count * 0.10 + customer.wallet.quarters.Count * 0.25 + customer.wallet.nickels.Count * 0.05 + customer.wallet.pennies.Count * 0.01;

            Console.WriteLine("");
            Console.WriteLine("Total: $" + total);
            
        }
    }
}
