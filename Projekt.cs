using System;
using System.Collections.Generic;
using System.IO;


namespace Zeit_Datum
{
    public class Projekt
    {
        private List<Workpackage> ls = new List<Workpackage>();
        public List<Workpackage> Load(string filename)
        {
            using(StreamReader reader = new StreamReader(filename))
            {
                ls.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Equals("")) continue;    
                    string[] parts = line.Split(';');
                    var number = parts[0];
                    var name = parts[1];
                    var d1 = int.Parse(parts[2]);
                    var duration = new TimeSpan(0, d1, 0);
                    var wp = new Workpackage(number, name, duration);
                    ls.Add(wp);
                }
                return ls;
            }
        }
        public void print()
        {
            ls.ForEach(Console.WriteLine);
        }
        public void PrintSchedule(DateTime start, int maxZeit)
        {
            var pause_duration = 30;
            var pause = new TimeSpan(0,pause_duration,0);
            var max_Zeit = new TimeSpan(0,maxZeit,0);;
            var nextPause = start + max_Zeit;
            var current = start;
            foreach (var wp in ls)
            {
                if (current >= nextPause)
                {
                    Console.WriteLine($"{current.Hour:00}:{current.Minute} {pause_duration}-min-Pause");
                    nextPause += pause + max_Zeit;
                    current += pause;
                }
                Console.WriteLine($"{current.Hour:00}:{current.Minute:00} {wp.number} {wp.name}");
                current += wp.duration;
            }
        }
        
    }
    
}