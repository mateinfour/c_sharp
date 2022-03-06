using System;
using System.Collections.Generic;

namespace Zeit_Datum
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Projekt();
            p.Load("../../../input1.txt");
            //p.print();
            p.PrintSchedule(new DateTime(1,1,1,8,0,0), 120);
            
        }

    }
}