using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean
    {
        private Cell[,] cells;
        private int width;
        private int hight;
        private int fishesNumber = 0;
        private int sharksNumber = 0;
        private int blocksNumber = 0;
        private int timeToFishReproduce;
        private Random rand = new Random();
        

        public Cell[,] Cells { get => cells; }
        public int FishNumber { get => fishesNumber; set => fishesNumber = value; }
        public int SharkNumber { get => sharksNumber; set => sharksNumber = value; }
        public int BlocksNumber { get => blocksNumber; set => blocksNumber = value; }
        public int Hight { get => hight; set => hight = value; }
        public int Width { get => width; set => width = value; }

        public Ocean(int width = 120, int hight = 25, int timeToReproduce = 30)
        {
            this.Width = width;
            this.Hight = hight;
            this.timeToFishReproduce = timeToReproduce;
            cells = new Cell[width, hight];
            Clear();
        }
        
        private void Clear()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Hight; j++)
                {
                    cells[i, j] = null;
                }
            }
        }
        //public void Run(int iter = 1)
        //{
        //    for (int i = 0; i < iter; i++)
        //    {
        //        foreach (Cell item in cells)
        //        {
        //            if (item==null)
        //            {
        //                continue;
        //            }

        //            if (isFish(item.Position))
        //            {
        //                (item as Fish).LifeCicleStep();
        //            }

        //            if (isShark(item.Position))
        //            {
        //                (item as Shark).LifeCicleStep();
        //            }
        //        }
        //    }
        //}

        public void PopulateOcean(IInitializer initializer)
        {
            initializer.Initialize(cells, Width, Hight);
        }
        
        public bool PointOutOfRange(Point p)
        {
            if (p.X >= Width || p.Y >= Hight || p.X < 0 || p.Y < 0)
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
            blocksNumber++;
        }
        public void CreateFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            cells[p.X, p.Y] = new Fish(p, SwopCell, CreateFish, GetRandomDirection, isCell, KillCell);
            fishesNumber++;
        }
        public void CreateShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            cells[p.X, p.Y] = new Shark(p, SwopCell, CreateShark, GetRandomDirection, isCell, KillCell, isFish);
            sharksNumber++;
        }
        public void Print()
        {
            char ico;
            Console.Clear();
            for (int i = 0; i < Hight; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    ico = '-';
                    if (cells[j, i] != null)
                    {
                        ico = cells[j, i].Icon;
                    }
                        Console.Write(ico);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Blocks: {blocksNumber}, sharks: {sharksNumber}, fishes: {fishesNumber}");
        }
        public bool isCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            return cells[p.X, p.Y] == null;

        }
        public bool isFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            if (cells[p.X, p.Y] is Fish && !(cells[p.X, p.Y] is Shark))
            {
                return true;
            }
            return false;
        }
        public bool isShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            if (cells[p.X, p.Y] is Shark)
            {
                return true;
            }
            return false;
        }
        public bool isBlock(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

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
            if (!isCell(p1))
            {
                cells[p1.X, p1.Y].Position = p1;
            }
            if (!isCell(p2))
            {
                cells[p2.X, p2.Y].Position = p2;
            }

        }
        public void KillCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            if (isFish(p))
            {
                fishesNumber--;
            }
            if (isShark(p))
            {
                sharksNumber--;
            }
            cells[p.X, p.Y] = null;

        }
        public Direction GetRandomDirection()
        {
            return (Direction)(rand.Next(0, 1000) % 4 + 1);
        }

    }
}
