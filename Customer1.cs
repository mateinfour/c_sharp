using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Threading;

namespace Lokalbesuch
{
    public class Customer1
    {
        public string name;
        public double money;
        public double drinkFinishedAt = 10;

        public Customer1(string name, int money)
        {
            this.name = name;
            this.money = money;
        }

        public void drink(Drink1 d)
        {
            drinkFinishedAt = Simulation2.clock + (double)d.duration / 60;
            money -= d.Price(Simulation2.clock);
        }

        public void start()
        {
            while (Simulation2.clock < 19)
            {
                if (drinkFinishedAt <= Simulation2.clock)
                {
                    var d = Simulation2.get_affordable_drink(money);
                    if (d != null)
                    {
                        drink(d);
                        Simulation2.drinkOrdered(d);
                        Console.WriteLine($"{name} drinks {d.name}, money: {money:F2}, time:{ Simulation2.clock:F2}, drinkFinishedAt: {drinkFinishedAt:F2}");
                    }
                    else
                    {
                        Simulation2.outOfMoney(this);
                        break;
                    }
                }


            }
        }
    }
}