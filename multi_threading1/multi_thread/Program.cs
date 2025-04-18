using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multi_thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing lunch...");

            Lunch lunch = new Lunch();
            lunch.Prepare();

            Console.WriteLine("Lunch is ready! Enjoy your meal.");
        }
        internal class Salad
        {
            public void Prepare()
            {
                Console.WriteLine("Preparing salad...");
                Thread.Sleep(2000); // Simulating preparation time
                Console.WriteLine("Salad is ready");
            }
        }

        internal class Soup
        {
            public void Prepare()
            {
                Console.WriteLine("Preparing soup...");
                Thread.Sleep(3000); // Simulating preparation time
                Console.WriteLine("Soup is ready");
            }
        }

        internal class MainCourse
        {
            public void Prepare()
            {
                Console.WriteLine("Preparing main course...");
                Thread.Sleep(4000); // Simulating preparation time
                Console.WriteLine("Main course is ready");
            }
        }

        internal class Lunch
        {
            private Salad salad;
            private Soup soup;
            private MainCourse mainCourse;

            public Lunch()
            {
                salad = new Salad();
                soup = new Soup();
                mainCourse = new MainCourse();
            }

            public void Prepare()
            {
                salad.Prepare();
                soup.Prepare();
                mainCourse.Prepare();
            }
        }
    }
}
