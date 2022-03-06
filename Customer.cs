using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokalbesuch
{
    class Customer
    {
        string name;
        float amountOfMoney;
        Drink drink;
        string currentdrink;

        private static Random random = new Random(5);

        public Customer(string name, float money, Drink drink)
        {
            this.name = name;
            this.amountOfMoney = money;
            this.drink = drink;
            drink.Drinks += Serve;
        }

        public void GetDrink()
        {
            //currentdrink = drink.listOfDrinks[random.Next()];

            //if duration = 10-11
            if (currentdrink.Equals(drink.listOfDrinks[0]))
                amountOfMoney -= 1;
            if (currentdrink.Equals(drink.listOfDrinks[1]))
                amountOfMoney -= 1;
            if (currentdrink.Equals(drink.listOfDrinks[2]))
                amountOfMoney -= 1;
            if (currentdrink.Equals(drink.listOfDrinks[3]))
                amountOfMoney -= 2.3f;
            if (currentdrink.Equals(drink.listOfDrinks[4]))
                amountOfMoney -= 2;
            if (currentdrink.Equals(drink.listOfDrinks[5]))
                amountOfMoney -= 2;




            if (amountOfMoney > 1)
                drink.Order(this);
            else
                OutOfMoney();
        }

        private void Serve(object sender, EventArgs e)
        {
            if(sender == this)
                Console.WriteLine($"Order {currentdrink} from customer {name} deliverd.");
        }

        private void OutOfMoney()
        {
            Console.WriteLine($"{name} is out of Money. His total vitaminsum is {drink.vitamin}");
        }
    }
}
