using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CircleTest();
        }
        static void CircleTest()
        {
            //Arrange
            Ocean ocean = new Ocean(20,20);
            Point testingPoint = new Point();
            testingPoint.X = 5;
            testingPoint.Y = 5;

            //Act
            ocean.CreateFish(testingPoint);

            while (true)
            {
                foreach (Cell item in ocean.Cells)
                {
                    if(item is Fish)
                    {
                        (item as Fish).LifeCicleStep();
                    }
                }
                //(ocean.Cells[testingPoint.X, testingPoint.Y] as Fish).LifeCicleStep();
                ocean.Print();
                Console.ReadKey();
            }



        }

    }
}
