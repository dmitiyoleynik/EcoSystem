using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Ocean
    {
        private Cell[,] cells;
        private int width, hight;
        private int timeToFishReproduce = 15;
        private Random rand = new Random();

        public Ocean(int width = 120, int hight = 25)
        {
            this.width = width;
            this.hight = hight;
            cells = new Cell[width, hight];
            Clear();
        }
        private void Clear()
        {
            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < hight - 1; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }
        public void CreateBlock(Point p)
        {
            cells[p.X, p.Y] = new Block(p);
        }
        public void CreateFish(Point p)
        {
            cells[p.X, p.Y] = new Fish(p, timeToFishReproduce, SwopCell, CreateFish, GetRandomDirection, isCell);
        }
        public void CreateShark(Point p)
        {
            cells[p.X, p.Y] = new Shark(p);
        }
        public void Print()
        {
            Console.Clear();
            for (int i = 0; i < hight - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    Console.Write(cells[j, i].Icon);
                }
                Console.WriteLine();
            }
        }
        public bool isCell(Point p)
        {
            if(cells[p.X,p.Y] is Fish)
            {
                return false;
            }
            return true;
        }
        public void SwopCell(Point p1, Point p2)
        {
            Cell tmp = cells[p1.X, p1.Y];
            cells[p1.X, p1.Y] = cells[p2.X, p2.Y];
            cells[p2.X, p2.Y] = tmp;
            cells[p1.X, p1.Y].Position = p1;
            cells[p2.X, p2.Y].Position = p2;

            //Point t = cells[p1.X, p1.Y].Position;
            //cells[p1.X, p1.Y].Position = cells[p2.X, p2.Y].Position;
            //cells[p2.X, p2.Y].Position = t;
        }
        public void KillCell(Point p)
        {
            cells[p.X, p.Y] = new Cell(p);
        }
        public Direction GetRandomDirection()
        {
            return (Direction)(rand.Next(0, 1000)%4);
        }
        //////////////////////
        public void TestFish(Point p)
        {
            CreateFish(p);
            Print();
            //Console.ReadKey();
            //((Fish)cells[p.X, p.Y]).LifeCicleStep();
            ////((Fish)cells[p.X, p.Y]).Move(Direction.Up);
            ////SwopCell(p, new Point { X = p.X, Y = p.Y-1 });
            //Print();
            //Console.ReadKey();
            //((Fish)cells[p.X, p.Y-1]).LifeCicleStep();
            //Print();
            while (true)
            {
                foreach (var item in cells)
                {
                    if (item is Fish)
                    {
                        ((Fish)item).LifeCicleStep();
                    }
                }
                Print();
                Console.ReadKey();
            }
        }
        ///

    }
}
