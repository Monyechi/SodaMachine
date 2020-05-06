using OopSodaMachine;
using SodaMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSodaMachine
{
    class Simulation
    {
        public Customer customer = new Customer();
        public SodaMachine sodaMachine = new SodaMachine();

        public Simulation()
        {
            Run();
        }
        public void Run()
        {
            sodaMachine.SelectSoda(customer);
        }
    }
}
