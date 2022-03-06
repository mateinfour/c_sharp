using System.Threading;

namespace Lokalbesuch
{
    public class Clock
    {
        private static double time;
        private static int interval = 2;
        public static void start(double c)
        {
            time = c;
            while (time <= 19)
            {
                Thread.Sleep(interval);
                time += 1.0 / 60;
            }
        }

        public static double Time
        {
            get => time;
        }
    }
}