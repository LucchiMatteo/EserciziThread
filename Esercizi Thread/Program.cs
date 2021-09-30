using System;
using System.Threading;
using System.IO;

namespace Esercizi_Thread
{
    
    class Program
    {
        static int a, b, c, tot=0;

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(part1));
            Thread t2 = new Thread(new ThreadStart(part2));
            Thread t3 = new Thread(new ThreadStart(part3));

            Console.WriteLine("Inserire il valore e");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserire il valore b");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserire il valore c");
            c = int.Parse(Console.ReadLine());

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Il risultato finale è: " + tot);

            Thread t4 = new Thread(new ThreadStart(MyThread.ThreadFile));
            Thread t5 = new Thread(new ThreadStart(MyThread.ThreadFact));

            t4.Start();
            t5.Start();

            t4.Join();
            t5.Join();
        }

        static void part1()
        {
            int res = b * 2;
            Console.WriteLine("Risultato prima parte " + res);
            tot += res;
        }

        static void part2()
        {
            int res = a + 5;
            Console.WriteLine("Risultato seconda parte " + res);
            tot -= res;
        }

        static void part3()
        {
            int res = c*c;
            Console.WriteLine("Risultato terza parte " + res);
            tot += res;
        }
    }

    class MyThread
    {

        public static void ThreadFile()
        {
            StreamReader sr = new StreamReader("input.txt");
            string s;
            int num = 0;
            while (sr.Peek() >= 0)
            {
                s = sr.ReadLine();

                if (s == "Thread")
                    num++;

            }

            Console.WriteLine("Il numero di apparizione della parola Thread è: " + num);
        }

        public static void ThreadFact()
        {
            int tot = 1;

            for(int i=1; i<10; i++)
            {
                tot *= i;
            }

            Console.WriteLine("Il fattoriale di 10 vale: " + tot);

        }

    }
}
