using System;
using System.Collections.Generic;

namespace Lokalbesuch
{
    public class Simulation1
    {
        private static double clk = 10;
        private static Random random = new Random();
        private static bool drinksPossible;
        public static int vitamins = 0;
        public static int numberOfDrinks = 0;
        public static List<Customer1> customers;
        public static List<Drink1> drinks;
        protected static void setup()
        {
            // customers
            Customer1 anton = new Customer1("anton", 50);
            Customer1 benjamin = new Customer1("benjamin", 50);
            Customer1 christina = new Customer1("christina", 50);
            Customer1 doris = new Customer1("doris", 50);
            Customer1 erem = new Customer1("erem", 50);
            customers = new List<Customer1>() { anton, benjamin, christina, doris, erem };
            // drinks
            Drink1 himbeer = new Drink1("BioHimbeer", 20, 3);
            himbeer.price1 = 1;
            himbeer.price2 = himbeer.price3 = 2.5;
            Drink1 smoothie = new Drink1("Smoothie", 30, 4);
            smoothie.price1 = 1;
            smoothie.price2 = 2.5;
            smoothie.price3 = 3.5;
            Drink1 wellness = new Drink1("WellnessDrink", 20, 3);
            wellness.price1 = 1;
            wellness.price2 = 2.5;
            wellness.price1 = 3.5;
            Drink1 apfel = new Drink1("Apfelsaft pur", 40, 2);
            apfel.price1 = apfel.price2 = apfel.price3 = 2.3;   
            Drink1 apfel_g = new Drink1("Apfelsaft gespritzt", 15, 3);
            apfel_g.price1 = apfel_g.price2 = apfel_g.price3 = 2;   
            Drink1 lychee = new Drink1("LycheeSaft", 5, 2);
            lychee.price1 = lychee.price2 = lychee.price3 = 2;
            drinks = new List<Drink1>(){ himbeer, smoothie, wellness, apfel, apfel_g, lychee };
        }
        public static void start()
        {
            setup();
            // main loop
            while (clock < 19)
            {
                //Console.WriteLine($"time: {clock:F2}");
                // assume nobody has money left to get a drink
                drinksPossible = false;
                // ask each customer in turn if he needs another drink
                foreach (var customer in customers)
                {
                    if (customer.money >= 2 || clock <= 11 && customer.money >= 1 )
                    {
                        // there is enough budget to get a drink. but are they ready to order?
                        drinksPossible = true;
                        if (customer.drinkFinishedAt <= clock)
                        {
                            Drink1 d = get_affordable_drink(customer.money);
                            if (d == null) continue;
                            customer.drink(d);
                            Console.WriteLine($"{customer.name} ordered {d.name}, money: {customer.money:F2}");
                            numberOfDrinks += 1;
                            vitamins += d.vitamin;
                        }
                    }
                }
                // nobody ordered, no further drinks possible -> out of money
                if (!drinksPossible) {Console.WriteLine($"drinksPossible {drinksPossible}, breaking"); break;}
                
                clock += 1.0/60;
            }
            // print drink number and vitamins
            Console.WriteLine($"simulation finished at: {clock:F2}\ntotal number of drinks ordered: {numberOfDrinks}, total vitamin: {vitamins}");
        }

        public static Drink1 get_affordable_drink(double money)
        {
            if (clock <= 11 && money < 1) return null;
            if(money < 2) return null;
            var ls = new List<int>() { 0, 1, 2, 3, 4, 5 };
            while (true)
            {
                var index = ls[random.Next(ls.Count)];
                Drink1 d = drinks[index];
                if (d.Price(clock) <= money)
                {
                    Console.WriteLine($"money: {money:F2}, drink: {d.name}, price: {d.Price(clock)}, time: {clock:F2}");
                    return d;
                }
                ls.Remove(index);
            }
        }
        public static double clock
        {
            get => clk;
            set { clk = value; }
        }

        
    }
    }

