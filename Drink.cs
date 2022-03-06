using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokalbesuch
{
    class Drink
    {
        public float price;
        public int vitamin;
        //public DateTime duration = new DateTime(2022, 2, 28, 10, 0, 0);
        public double duration;
        public string nameOfDrink;

        public Drink(string nameOfDrink, int vitamin, double duration)
        {
            this.nameOfDrink = nameOfDrink; 
            this.vitamin = vitamin;
            this.duration = duration;
        }

        public Drink() { }

        public List<Drink> listOfDrinks = new List<Drink>
        {
            new Drink("BioHimbeer",GetPrice(),20),
            new Drink("Smoothie",GetPrice(),4.30),
            new Drink("WellnessDrink",GetPrice(),3.20),
            new Drink("Apfelsaft pur",GetPrice(),2.40),
            new Drink("Apfelsaft gespritzt",GetPrice(),2.15),
            new Drink("LycheeSaft",GetPrice(),2.5),
        };

        private static int GetPrice()
        {
            return 0;
        }

        public void Order(Customer c)
        {
            Drinks?.Invoke(c, new EventArgs());
        }

        public EventHandler Drinks;
    }
}
