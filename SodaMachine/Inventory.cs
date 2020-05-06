using OopSodaMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Inventory
    {
        // member variables (HAS A)
        public List<Lemon> lemonSoda;
        public List<Grape> grapeSoda;
        public List<Orange> orangeSoda;

        // constructor (SPAWNER)
        public Inventory()
        {
            lemonSoda = new List<Lemon>();
            for (int i = 0; i < 10; i++)
            {
                lemonSoda.Add(new Lemon());
            }

            grapeSoda = new List<Grape>();
            for (int i = 0; i < 15; i++)
            {
                grapeSoda.Add(new Grape());
            }
            orangeSoda = new List<Orange>();
            for (int i = 0; i < 1; i++)
            {
                orangeSoda.Add(new Orange());
            }
        }
    }
}
