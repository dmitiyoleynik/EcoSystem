﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class RandomInitializer: IInitializer
    {
        #region consts

        protected const int DEFAULT_SHARKS_NUMBER = 20;
        protected const int DEFAULT_FISHES_NUMBER = 20;
        protected const int DEFAULT_BLOCKS_NUMBER = 150;
        
        #endregion

        #region fields 
        
        private Random _rand = new Random();
        private Ocean _ocean;
        
        #endregion   
        public RandomInitializer(Ocean ocean)
        {
            _ocean = ocean;
        }

        public void Initialize(int widthRange, int higthRange)
        {
            SetBlocksRandom(widthRange, higthRange);
            SetFishesRandom(widthRange, higthRange);
            SetSharksRandom(widthRange, higthRange);
        }
        
        public void SetSharksRandom(int width, int hight, int number = DEFAULT_SHARKS_NUMBER)
        {
            for (int i = 0; i < number; i++)
            {
                Point point = GetRandomPoint(width, hight);

                if (FishManager.IsCell(point, _ocean))
                {
                    FishManager.CreateShark(point, _ocean);
                }
                else
                {
                    i--;
                }
            }
        }
       
        public void SetFishesRandom(int width, int hight, int number = DEFAULT_FISHES_NUMBER)
        {
            for (int i = 0; i < number; i++)
            {
                Point point = GetRandomPoint(width, hight);

                if (FishManager.IsCell(point, _ocean))
                {
                    FishManager.CreateFish(point, _ocean);
                }
                else
                {
                    i--;
                }
            }
        }
       
        public void SetBlocksRandom(int width, int hight, int number = DEFAULT_BLOCKS_NUMBER)
        {
            for (int i = 0; i < number; i++)
            {
                Point point = GetRandomPoint(width, hight);

                if (FishManager.IsCell(point, _ocean))
                {
                    FishManager.CreateBlock(point, _ocean);
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
