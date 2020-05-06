using OopSodaMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSodaMachine
{
    class Wallet
    {
        public List<Quarter> quarters;
        public List<Dime> dimes;
        public List<Nickel> nickels;
        public List<Penny> pennies;
        public double total;
        public Wallet(Random random)
        {
            int x = random.Next(1, 10);

            quarters = new List<Quarter>();
            for (int i = 0; i < x; i++)
            {
                quarters.Add(new Quarter());
            }
            int totalQuarters = quarters.Count;
            double quartersValue = quarters.Count * 0.25;
            nickels = new List<Nickel>();
            for (int i = 0; i < x; i++)
            {
                nickels.Add(new Nickel());
            }
            int totalNickels = nickels.Count;
            double NickelsValue = nickels.Count * 0.05;
            dimes = new List<Dime>();
            for (int i = 0; i < x; i++)
            {
                dimes.Add(new Dime());
            }
            int totalDimes = dimes.Count;
            double dimesValue = dimes.Count * 0.10;
            pennies = new List<Penny>();
            for (int i = 0; i < x; i++)
            {
                pennies.Add(new Penny());
            }
            int totalPennies = pennies.Count;
            double pennyValue = pennies.Count * 0.25;

            total = quartersValue + pennyValue + NickelsValue + dimesValue;

        }
        
    }
}
