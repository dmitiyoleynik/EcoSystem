using System;

namespace EcoSystem
{
    static class RandomBehavior 
    {
        private static Random _rand = new Random();

        public static Direction GetRandomDirection()
        {
            return (Direction)(_rand.Next(0, 4) + 1);
        }
    }
}
