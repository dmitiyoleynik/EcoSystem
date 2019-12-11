using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    static class FishManager 
    {
        #region variables 
        static RandomBehavior _randomBehavior = new RandomBehavior();
        #endregion

        static public bool PointOutOfRange(Point p,Ocean ocean)
        {
            if (p.X >= ocean.Width || p.Y >= ocean.Hight || p.X < 0 || p.Y < 0)
            {
                return true;
            }
            else return false;
        }

        static public void CreateBlock(Point p, Ocean ocean)
        {
            if (PointOutOfRange(p, ocean))
            {
                return;
            }

            ocean[p.X, p.Y] = new Block(p);
            //_blocksNumber++;
        }

        static public void CreateFish(Point p, Ocean ocean)
        {
            if (PointOutOfRange(p,ocean))
            {
                return;
            }

            ocean[p.X, p.Y] = new Fish(p, ocean);
            //_fishesNumber++;
        }

        static public void CreateShark(Point p,Ocean ocean)
        {
            if (PointOutOfRange(p, ocean))
            {
                return;
            }

            ocean[p.X, p.Y] = new Shark(p, ocean);
            //_sharksNumber++;
        }

        static public bool isCell(Point p, Ocean ocean)
        {
            bool result;

            if (PointOutOfRange(p,ocean))
            {
                result = false;
            }
            else
            {
                result = ocean[p.X, p.Y] == null;
            }

            return result;
        }

        static public bool isBlock(Point p, Ocean ocean)
        {
            bool result = false;

            if (PointOutOfRange(p, ocean))
            {
                result = false;
            }
            else if (ocean[p.X, p.Y] is Block)
            {
                result = true;
            }

            return result;

        }

        static public bool isFish(Point p, Ocean ocean)
        {
            bool result = false; 
            if (PointOutOfRange(p, ocean))
            {
                result = false;
            }
            else if(ocean[p.X, p.Y] is Fish && !(ocean[p.X, p.Y] is Shark))
            {
                result = true;
            }
            

            return result;

        }

        static public bool isShark(Point p, Ocean ocean)
        {
            bool result = false;

            if (PointOutOfRange(p, ocean))
            {
                result = false;
            }
            else if(ocean[p.X, p.Y] is Shark)
            {
                result = true;
            }

            return result;

        }

        static public void ClearOcean( Ocean ocean)
        {
            for (int i = 0; i < ocean.Width; i++)
            {
                for (int j = 0; j < ocean.Hight; j++)
                {
                    ocean[i, j] = null;
                }
            }
        }

        static public void KillCell(Point p, Ocean ocean)
        {
            if (PointOutOfRange(p, ocean))
            {
                return;
            }

            if (isFish(p, ocean))
            {
                //_fishesNumber--;
            }
            if (isShark(p, ocean))
            {
                //_sharksNumber--;
            }
            ocean[p.X, p.Y] = null;
        }

        static public void SwopCell(Point p1, Point p2, Ocean ocean)
        {
            if (PointOutOfRange(p1, ocean) || PointOutOfRange(p2, ocean))
            {
                return;
            }

            Cell tmp = ocean[p1.X, p1.Y];
            ocean[p1.X, p1.Y] = ocean[p2.X, p2.Y];
            ocean[p2.X, p2.Y] = tmp;
            if (!isCell(p1, ocean))
            {
                ocean[p1.X, p1.Y].Position = p1;
            }
            if (!isCell(p2, ocean))
            {
                ocean[p2.X, p2.Y].Position = p2;
            }

        }

        static public Direction GetDir()
        {
            return _randomBehavior.GetRandomDirection();
        }
    }
}
