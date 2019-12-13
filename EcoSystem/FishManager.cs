using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    static class FishManager 
    {
        #region variables 
        static RandomBehavior _randomBehavior = new RandomBehavior();
        static FishPlay _fishPlay;
        #endregion

        static public bool PointOutOfRange(Point p,Ocean ocean)
        {
            if (p.X >= ocean.Width || p.Y >= ocean.Hight || p.X < 0 || p.Y < 0)
            {
                return true;
            }
            else return false;
        }

        static public void SetFishPlay(FishPlay fishPlay)
        {
            _fishPlay = fishPlay;
        }

        static public void CreateBlock(Point p, Ocean ocean)
        {
            if (PointOutOfRange(p, ocean))
            {
                return;
            }

            ocean[p.X, p.Y] = new Block(p);
            ocean.BlocksNumber++;
        }

        static public void CreateFish(Point p, Ocean ocean)
        {
            if (PointOutOfRange(p,ocean))
            {
                return;
            }

            ocean[p.X, p.Y] = new Fish(p, ocean);
            ocean.FishesNumber++;
            _fishPlay.Play += (ocean[p.X, p.Y] as Fish).LifeCicleStep;
        }

        static public void CreateShark(Point p,Ocean ocean)
        {
            if (PointOutOfRange(p, ocean))
            {
                return;
            }

            ocean[p.X, p.Y] = new Shark(p, ocean);
           ocean.SharksNumber++;
            _fishPlay.Play += (ocean[p.X, p.Y] as Shark).LifeCicleStep;
        }

        static public bool IsCell(Point p, Ocean ocean)
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

        static public bool IsBlock(Point p, Ocean ocean)
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

        static public bool IsFish(Point p, Ocean ocean)
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

        static public bool IsShark(Point p, Ocean ocean)
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

            if (IsFish(p, ocean))
            {
               ocean.FishesNumber--;
               _fishPlay.Play += (ocean[p.X, p.Y] as Fish).LifeCicleStep;

            }
            if (IsShark(p, ocean))
            {
                ocean.SharksNumber--;
               _fishPlay.Play += (ocean[p.X, p.Y] as Shark).LifeCicleStep;
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
            if (!IsCell(p1, ocean))
            {
                ocean[p1.X, p1.Y].Position = p1;
            }
            if (!IsCell(p2, ocean))
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
