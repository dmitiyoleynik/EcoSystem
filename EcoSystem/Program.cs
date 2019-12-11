using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Puppeteer puppeteer = new Puppeteer();
            puppeteer.InitOcean();
            while (true)
            {
                puppeteer.PrintOcean();
                Console.ReadKey();
                puppeteer.Play();
            }
            puppeteer.PrintOcean();
            puppeteer.Play();
            puppeteer.PrintOcean();

        }
    }
}
