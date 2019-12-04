using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CircleTest();
        }

        /// <summary>
        /// Method need to test Fish.LifeCicleStep() manually
        /// I know that sometimes fish doesn't do any actions
        /// and sometimes it makes two actions like do up twice
        /// or go up and right or like that
        /// It's because of foreach method that can execute this method twice
        /// but I don't think that it is a mistake
        /// </summary>
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
                ocean.Print();
                Console.ReadKey();
            }



        }

    }
}
