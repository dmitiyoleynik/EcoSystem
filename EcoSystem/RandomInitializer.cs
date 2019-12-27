using System;

namespace EcoSystem
{
    class RandomInitializer: IInitializer
    {
        #region fields 
        
        private Random _rand = new Random();
        private ICellContainer _ocean;
        
        #endregion   
        public RandomInitializer(ICellContainer ocean)
        {
            _ocean = ocean;
        }

        public void Initialize()
        {
            SetBlocksRandom(_ocean.Width, _ocean.Hight);
            SetFishesRandom(_ocean.Width, _ocean.Hight);
            SetSharksRandom(_ocean.Width, _ocean.Hight);
        }
        
        public void SetSharksRandom(int width, int hight,
            int number = Constants.DEFAULT_SHARKS_NUMBER)
        {
            for (int i = 0; i < number; i++)
            {
                Point point = GetRandomPoint(width, hight);

                if (_ocean.IsCell(point))
                {
                    Shark newBlock = new Shark(point);
                    _ocean.SetCell(point, newBlock,newBlock.LifeCicleStep);
                }
                else
                {
                    i--;
                }
            }
        }
       
        public void SetFishesRandom(int width, int hight,
            int number = Constants.DEFAULT_FISHES_NUMBER)
        {
            for (int i = 0; i < number; i++)
            {
                Point point = GetRandomPoint(width, hight);

                if (_ocean.IsCell(point))
                {
                    Fish newBlock = new Fish(point);
                    _ocean.SetCell(point, newBlock,newBlock.LifeCicleStep);
                }
                else
                {
                    i--;
                }
            }
        }
       
        public void SetBlocksRandom(int width, int hight,
            int number = Constants.DEFAULT_BLOCKS_NUMBER)
        {
            for (int i = 0; i < number; i++)
            {
                Point point = GetRandomPoint(width, hight);

                if (_ocean.IsCell(point))
                {
                    Cell newBlock = new Block(point);
                    _ocean.SetCell(point, newBlock,null);
                }
                else
                {
                    i--;
                }
            }
        }

        public Point GetRandomPoint(int width, int hight)
        {
            int x = _rand.Next(0, width);
            int y = _rand.Next(0, hight);
            Point point = new Point { X = x, Y = y };

            return point;
        }

    }
}
