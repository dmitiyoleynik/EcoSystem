using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class RandomBehavior : IRandomBehavior
    {
        private Random _rand = new Random();

        public Direction GetRandomDirection()
        {
            return (Direction)(_rand.Next(0, 1000) % 4 + 1);
        }
    }
}
