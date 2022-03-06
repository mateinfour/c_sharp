using System;

namespace Zeit_Datum
{
    public class Workpackage
    {
        public string number;
        public  string name;
        public  TimeSpan duration;

        public Workpackage(string number, string name, TimeSpan duration)
        {
            this.number = number;
            this.name = name;
            this.duration = duration;
        }

        public override string ToString()
        {
            return $"{number};{name};{duration}";
        }
        
        
        
    }
}