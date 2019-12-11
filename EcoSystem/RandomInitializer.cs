using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class RandomInitializer: IInitializer
    {
        private Random _rand = new Random();
        IFishCreator _creator;
        public RandomInitializer(IFishCreator creator)
        {
            _creator = creator;
        }

        public void Initialize(Cell[,] cells,int widthRange,int higthRange)
        {
            SetBlocksRandom(widthRange, higthRange);
            SetFishesRandom(widthRange, higthRange);
            SetSharksRandom(widthRange, higthRange);
        }
        public void SetSharksRandom(int width, int hight, int number = 20)
        {
            for (int i = 0; i < number; i++)
            {
                int x = _rand.Next(0, width);
                int y = _rand.Next(0, hight);
                if (_creator.isCell(new Point { X = x, Y = y }))
                {
                   _creator.CreateShark(new Point { X = x, Y = y });
                }
            }
        }
        public void SetFishesRandom(int width, int hight, int number = 20)
        {
            for (int i = 0; i < number; i++)
            {
                int x = _rand.Next(0, width);
                int y = _rand.Next(0, hight);
                if (_creator.isCell(new Point { X = x, Y = y }))
                {
                    _creator.CreateFish(new Point { X = x, Y = y });
                }
            }
        }
        public void SetBlocksRandom(int width, int hight, int number = 150)
        {
            for (int i = 0; i < number; i++)
            {
                int x = _rand.Next(0, width);
                int y = _rand.Next(0, hight);
                if (_creator.isCell(new Point { X = x, Y = y }))
                {
                    _creator.CreateBlock(new Point { X = x, Y = y });
                }
            }
        }

    }
}
