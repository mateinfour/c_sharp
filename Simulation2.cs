using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lokalbesuch
{
    public class Simulation2 :Simulation1
    {
        private static HashSet<Customer1> no_money = new HashSet<Customer1>();
        
        public new static double clock
        {
            get => Clock.Time;
        }

        public new static  void start()
        {
            setup();
            Task.Run(() => Clock.start(10));
            foreach (var c in customers)
            {
                Task.Run(() => c.start());
            }

            while (no_money.Count < customers.Count && clock < 19)
            {
                Thread.Sleep(100);
                //Console.WriteLine($"time: {Simulation2.clock:F2}");
            }
            // print drink number and vitamins
            Console.WriteLine($"simulation finished at: {clock:F2}\ntotal number of drinks ordered: {numberOfDrinks}, total vitamin: {vitamins}");
            Console.WriteLine($"customers out of money:");
            no_money.ToList().ForEach(x=>Console.WriteLine(x.name));
        }

        public static void drinkOrdered(Drink1 d)
        {
            numberOfDrinks += 1;
            vitamins += d.vitamin;
        }

        public static void outOfMoney(Customer1 c)
        {
            no_money.Add(c);
            Console.WriteLine($"{c.name} out of money: {c.money}");
        }
        
        
    }
}