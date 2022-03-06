
namespace Lokalbesuch
{
    public class Drink1
    {
        public int vitamin;
        public string name;
        public int duration;
        public double price1;
        public double price2;
        public double price3;

        public Drink1(string name, int duration, int vitamin)
        {
            this.name = name;
            this.duration = duration;
            this.vitamin = vitamin;
        }
        public double Price(double clock)
        {
            return clock <= 11? price1 : clock <= 12? price2 : price3;
        }
    }
}