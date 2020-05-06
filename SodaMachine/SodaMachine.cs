using OopSodaMachine;
using SodaMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSodaMachine
{
    class SodaMachine : Simulation
    {
        public List<Quarter> quartersInMachine;
        public List<Dime> dimesInMachine;
        public List<Nickel> nickelsInMachine;
        public List<Penny> penniesInMachine;
        public double paymentRecieved;
        public double change;
        public int nickelsToInsert;
        public int dimesToInsert;
        public int quartersToInsert;
        public int penniesToInsert;
        public Penny penny = new Penny();
        public Quarter quarter = new Quarter();
        public Dime dime = new Dime();
        public Nickel nickel = new Nickel();
        public Inventory inventory;
        public Grape grape;
        public Lemon lemon;
        public Orange orange;

        public SodaMachine()
        {
            quartersInMachine = new List<Quarter>();
            for (int i = 0; i < 20; i++)
            {
                quartersInMachine.Add(new Quarter());
            }
            nickelsInMachine = new List<Nickel>();
            for (int i = 0; i < 20; i++)
            {
                nickelsInMachine.Add(new Nickel());
            }
            dimesInMachine = new List<Dime>();
            for (int i = 0; i < 10; i++)
            {
                dimesInMachine.Add(new Dime());
            }
            penniesInMachine = new List<Penny>();
            for (int i = 0; i < 50; i++)
            {
                penniesInMachine.Add(new Penny());
            }
            inventory = new Inventory();
        }
        public double InsertCash(Customer customer)
        {
            Console.WriteLine("Please insert quarters, dimes, nickels and pennies only!");
            Console.WriteLine("");
            Console.WriteLine("*Quarters to be inserted:*");
            InsertQuarters(customer);
            Console.WriteLine("");
            Console.WriteLine("*Dimes to be inserted:*");
            InsertDimes(customer);
            Console.WriteLine("");
            Console.WriteLine("*Nickels to be inserted:*");
            InsertNickels(customer);
            Console.WriteLine("");
            Console.WriteLine("*Pennies to be inserted:*");
            InsertPennies(customer);
            double total = InsertQuarters(customer) + InsertDimes(customer) + InsertNickels(customer) + InsertPennies(customer);

            Console.WriteLine("You inserted $" + total + " dollars");
            for (int i = 0; i < total; i++)
            {
                quartersInMachine.Add(new Quarter());
                Console.WriteLine("*" + i + " quarters inserted*");
            }
            return total;


        }
        public double InsertQuarters(Customer customer)
        {
             quartersToInsert = int.Parse(Console.ReadLine());
            if (quartersToInsert > customer.wallet.quarters.Count)
            {
                Console.WriteLine("You dont have " + quartersToInsert + " quarters. You only have " + customer.wallet.quarters.Count);
                InsertQuarters(customer);
            }
            else if (quartersToInsert <= customer.wallet.quarters.Count)
            {
                for (int i = 0; i < quartersToInsert; i++)
                {
                    quartersInMachine.Add(new Quarter());
                    Console.WriteLine("*" + i + " quarters inserted*");
                }

            }
            double totalValue = quartersToInsert * 0.25;
            return totalValue;

        }
        public double InsertDimes(Customer customer)
        {
             dimesToInsert = int.Parse(Console.ReadLine());
            if (dimesToInsert > customer.wallet.dimes.Count)
            {
                Console.WriteLine("You dont have " + dimesToInsert + " quarters. You only have " + customer.wallet.quarters.Count);
                InsertQuarters(customer);
            }
            else if (dimesToInsert <= customer.wallet.dimes.Count)
            {
                for (int i = 0; i < dimesToInsert; i++)
                {
                    dimesInMachine.Add(new Dime());
                    Console.WriteLine("*" + i + " dimes inserted*");
                }

            }
            double totalValue = dimesToInsert * 0.10;
            return totalValue;

        }
        public double InsertNickels(Customer customer)
        {
             nickelsToInsert = int.Parse(Console.ReadLine());
            if (nickelsToInsert > customer.wallet.dimes.Count)
            {
                Console.WriteLine("You dont have " + nickelsToInsert + " quarters. You only have " + customer.wallet.nickels.Count);
                InsertQuarters(customer);
            }
            else if (nickelsToInsert <= customer.wallet.dimes.Count)
            {
                for (int i = 0; i < nickelsToInsert; i++)
                {
                    nickelsInMachine.Add(new Nickel());
                    Console.WriteLine("*" + i + " nickels inserted*");
                }

            }
            double totalValue = nickelsToInsert * 0.05;
            return totalValue;

        }
        public double InsertPennies(Customer customer)
        {
             penniesToInsert = int.Parse(Console.ReadLine());
            if (penniesToInsert > customer.wallet.dimes.Count)
            {
                Console.WriteLine("You dont have " + penniesToInsert + " pennies. You only have " + customer.wallet.pennies.Count);
                InsertQuarters(customer);
            }
            else if (penniesToInsert <= customer.wallet.dimes.Count)
            {
                for (int i = 0; i < penniesToInsert; i++)
                {
                    penniesInMachine.Add(new Penny());
                    Console.WriteLine("*" + i + " pennies inserted*");
                }

            }
            double totalValue = penniesToInsert * 0.01;
            return totalValue;

        }
        public void SelectSoda(Customer customer)
        {
            Console.WriteLine("What would you like to purchase?\n1) Grape Soda\n2) Orange Soda\n3) Lemon Soda");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    //Purchase Grape Soda
                    double totalGrapeCost = GrapeSodaToSell(customer);
                    double totalGrapeCashInserted = InsertCash(customer);
                    if (sodaMachine.inventory.grapeSoda.Count == 0)
                    {
                        Console.WriteLine("Sorry, no more grape soda.");
                    }
                    if (totalGrapeCost > totalGrapeCashInserted)
                    {
                        Console.WriteLine("Insufficient Funds! Transaction Canceled.");
                        for (int i = 0; i < penniesToInsert; i++)
                        {
                            customer.wallet.pennies.Add(penny);
                            penniesInMachine.Remove(penny);
                        }
                        for (int i = 0; i < dimesToInsert; i++)
                        {
                            customer.wallet.dimes.Add(dime);
                            dimesInMachine.Remove(dime);
                        }
                        for (int i = 0; i < nickelsToInsert; i++)
                        {
                            customer.wallet.nickels.Add(nickel);
                            nickelsInMachine.Remove(nickel);
                        }
                        for (int i = 0; i < quartersToInsert; i++)
                        {
                            customer.wallet.quarters.Add(quarter);
                            quartersInMachine.Remove(quarter);
                        }
                        InsertCash(customer);
                    }
                    else if (totalGrapeCost <= totalGrapeCashInserted)
                    {
                        Console.WriteLine("Here is your grape soda.");
                        Console.WriteLine("Your chaange is ");
                    }
                    break;
                case "2":
                    //Purchase Orange Soda
                    double totalOrangeCost = OrangeSodaToSell(customer);
                    double totalOrangeCashInserted = InsertCash(customer);
                    if (sodaMachine.inventory.grapeSoda.Count == 0)
                    {
                        Console.WriteLine("Sorry, no more grape soda.");
                    }
                    if (totalOrangeCost > totalOrangeCashInserted)
                    {
                        Console.WriteLine("Insufficient Funds! Transaction Canceled.");
                        for (int i = 0; i < penniesToInsert; i++)
                        {
                            customer.wallet.pennies.Add(penny);
                            penniesInMachine.Remove(penny);
                        }
                        for (int i = 0; i < dimesToInsert; i++)
                        {
                            customer.wallet.dimes.Add(dime);
                            dimesInMachine.Remove(dime);
                        }
                        for (int i = 0; i < nickelsToInsert; i++)
                        {
                            customer.wallet.nickels.Add(nickel);
                            nickelsInMachine.Remove(nickel);
                        }
                        for (int i = 0; i < quartersToInsert; i++)
                        {
                            customer.wallet.quarters.Add(quarter);
                            quartersInMachine.Remove(quarter);
                        }
                        InsertCash(customer);
                    }
                    else if (totalOrangeCost <= totalOrangeCashInserted)
                    {
                        Console.WriteLine("Here is your grape soda.");
                        Console.WriteLine("Your chaange is ");
                    }
                    break;
                case "3":
                    //Purchase Lemon Soda
                    LeomonSodaToSell(customer);
                    double totalLemonCost = OrangeSodaToSell(customer);
                    double totalLemonCashInserted = InsertCash(customer);
                    if (sodaMachine.inventory.grapeSoda.Count == 0)
                    {
                        Console.WriteLine("Sorry, no more grape soda.");
                    }
                    if (totalLemonCost > totalLemonCashInserted)
                    {
                        Console.WriteLine("Insufficient Funds! Transaction Canceled.");
                        for (int i = 0; i < penniesToInsert; i++)
                        {
                            customer.wallet.pennies.Add(penny);
                            penniesInMachine.Remove(penny);
                        }
                        for (int i = 0; i < dimesToInsert; i++)
                        {
                            customer.wallet.dimes.Add(dime);
                            dimesInMachine.Remove(dime);
                        }
                        for (int i = 0; i < nickelsToInsert; i++)
                        {
                            customer.wallet.nickels.Add(nickel);
                            nickelsInMachine.Remove(nickel);
                        }
                        for (int i = 0; i < quartersToInsert; i++)
                        {
                            customer.wallet.quarters.Add(quarter);
                            quartersInMachine.Remove(quarter);
                        }
                        InsertCash(customer);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    SelectSoda(customer);
                    break;
            }

        }
        public double GrapeSodaToSell(Customer customer)
        {    
            Console.WriteLine("How many do you want?");
            int quantity = int.Parse(Console.ReadLine());
            int result = 0;
            if (int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid entry, Try again");
                GrapeSodaToSell(customer);
            }

            double totalCost = quantity * 0.60;
            Console.WriteLine("Total cost: $" + totalCost);
            return totalCost;
        }

        public double LeomonSodaToSell(Customer customer)
        {
            Console.WriteLine("How many do you want?");
            int quantity = int.Parse(Console.ReadLine());
            int result = 0;
            if (int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid entry, Try again");
                LeomonSodaToSell(customer);
            }

            double totalCost = quantity * 0.60;
            return totalCost;
        }

        public double OrangeSodaToSell(Customer customer)
        {
            Console.WriteLine("How many do you want?");
            int quantity = int.Parse(Console.ReadLine());
            int result = 0;
            if (int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid entry, Try again");
                OrangeSodaToSell(customer);
            }

            double totalCost = quantity * 0.60;
            return totalCost;
        }

    }
}
