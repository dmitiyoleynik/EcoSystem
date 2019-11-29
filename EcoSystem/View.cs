using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    static class View
    {
        static public void PrintOcean()
        {
            try
            {
                Ocean o = new Ocean();
                o.Print();
                Console.ReadKey();
                o.CreateBlock(new Point { X = 5, Y = 7 });
                o.CreateFish(new Point { X = 15, Y = 17 });
                o.CreateShark(new Point { X = 12, Y = 12 });
                o.Print();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
