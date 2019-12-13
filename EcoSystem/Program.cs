using System;
using System.Text;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Puppeteer puppeteer = new Puppeteer();
            puppeteer.InitOcean();
            puppeteer.PrintOcean();
            //Console.Read();
            //puppeteer.Test();
            //puppeteer.PrintOcean();

            while (true)
            {
                puppeteer.PrintOcean();
                Console.ReadKey();
                puppeteer.Play();
            }


            //FishPlay play = new FishPlay();
            //A a1 = new A(5);
            //A a2 = new A(6);
            //A a3 = new A(7);

            //play.Play += delegate
            //{
            //    Console.WriteLine("Hi from delegate!");
            //};

            //play.Play += a1.AOut;
            //play.Play += a2.AOut;
            //play.Play += a3.AOut;

            //play.Invoke();

            //Console.WriteLine("Delete val 6");
            //play.Play -= a2.AOut;
            //a2 = null;

            //play.Invoke();

        }
        class A
        {
            int val;
            public A(int v)
            {
                val = v;
            }
            public void AOut()
            {
                Console.WriteLine($"From class A val = {val}");
            }
        }
    }
}
