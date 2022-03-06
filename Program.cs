using System;

namespace Lokalbesuch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simulation1.start();
            Simulation2.start();
            

        }
        static void start(string[] args)
        {
            Drink drink = new Drink();
            Customer customer1 = new Customer("Anton", 50, drink);
            Customer customer2 = new Customer("Benjamin", 50, drink);
            Customer customer3 = new Customer("Christina", 50, drink);
            Customer customer4 = new Customer("Doris", 50, drink);
            Customer customer5 = new Customer("Erem", 50, drink);

            customer1.GetDrink();
            customer2.GetDrink();
            customer3.GetDrink();
            customer4.GetDrink();
            customer5.GetDrink();

            Console.ReadKey();
        }
    }
}