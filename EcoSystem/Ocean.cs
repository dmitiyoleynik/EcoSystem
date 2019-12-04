using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean
    {
        private Cell[,] cells;
        private int width, hight;
        private int timeToFishReproduce;
        private Random rand = new Random();

        public Cell[,] Cells { get => cells; }
        public int Width { get; }
        public int Hight { get; }
        public Ocean(int width = 120, int hight = 25, int timeToReproduce = 30)
        {
            this.width = width;
            this.hight = hight;
            this.timeToFishReproduce = timeToReproduce;
            cells = new Cell[width, hight];
            Clear();
        }
        private void Clear()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }
        public bool PointOutOfRange(Point p)
        {
            if (p.X >= width || p.Y >= hight || p.X < 0 || p.Y < 0)
            {
                return true;
            }
            else return false;
        }
        public void CreateBlock(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            cells[p.X, p.Y] = new Block(p);
        }
        public void CreateFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            cells[p.X, p.Y] = new Fish(p, SwopCell, CreateFish, GetRandomDirection, isCell, KillCell);
        }
        public void CreateShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            cells[p.X, p.Y] = new Shark(p);
        }
        public void Print()
        {
            Console.Clear();
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(cells[j, i].Icon);
                }
                Console.WriteLine();
            }
        }
        public bool isCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            if (cells[p.X, p.Y] is Fish || cells[p.X, p.Y] is Shark || cells[p.X, p.Y] is Block)
            {
                return false;
            }
            return true;
        }
        public bool isFish(Point p)
        {
            if (cells[p.X, p.Y] is Fish)
            {
                return true;
            }
            return false;
        }
        public bool isShark(Point p)
        {
            if (cells[p.X, p.Y] is Shark)
            {
                return true;
            }
            return false;
        }
        public bool isBlock(Point p)
        {
            if (cells[p.X, p.Y] is Block)
            {
                return true;
            }
            return false;
        }
        public void SwopCell(Point p1, Point p2)
        {
            if (PointOutOfRange(p1) || PointOutOfRange(p2))
            {
                return;
            }

            Cell tmp = cells[p1.X, p1.Y];
            cells[p1.X, p1.Y] = cells[p2.X, p2.Y];
            cells[p2.X, p2.Y] = tmp;
            cells[p1.X, p1.Y].Position = p1;
            cells[p2.X, p2.Y].Position = p2;

        }
        public void KillCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            cells[p.X, p.Y] = new Cell(p);
        }
        public Direction GetRandomDirection()
        {
            return (Direction)(rand.Next(0, 1000) % 4 + 1);
        }

    }
}
