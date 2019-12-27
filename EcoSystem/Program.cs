using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Puppeteer puppeteer = new Puppeteer();
            puppeteer.InitOcean();
            puppeteer.PrintOcean();

            while (true)
            {
                puppeteer.PrintOcean();
                Console.ReadKey();
                puppeteer.Play();
            }
        }
    }
}
