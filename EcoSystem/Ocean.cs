﻿using System;
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
        public int Width { get; }
        public int Hight { get; }
        public int FishNumber { get => fishesNumber; set => fishesNumber = value; }
        public int SharkNumber { get => sharksNumber; set => sharksNumber = value; }
        public int BlocksNumber { get => blocksNumber; set => blocksNumber = value; }

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
                    cells[i, j] = null;
                }
            }
        }
        public void Run(int iter = 1)
        {
            for (int i = 0; i < iter; i++)
            {
                foreach (Cell item in cells)
                {
                    if (item==null)
                    {
                        continue;
                    }

                    if (isFish(item.Position))
                    {
                        (item as Fish).LifeCicleStep();
                    }

                    if (isShark(item.Position))
                    {
                        (item as Shark).LifeCicleStep();
                    }
                }
            }
        }

        public void PopulateOcean(int blocksNumber, int fishesNumber, int sharksNumber)
        {
            SetBlocksRandom(blocksNumber);
            SetFishesRandom(fishesNumber);
            SetSharksRandom(sharksNumber);
        }
        public void SetSharksRandom(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int x = rand.Next(0, width);
                int y = rand.Next(0, hight);
                if (isCell(new Point { X = x, Y = y }))
                {
                    CreateShark(new Point { X = x, Y = y });
                }
            }
        }
        public void SetFishesRandom(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int x = rand.Next(0, width);
                int y = rand.Next(0, hight);
                if (isCell(new Point { X = x, Y = y }))
                {
                    CreateFish(new Point { X = x, Y = y });
                }
            }
        }
        public void SetBlocksRandom(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int x = rand.Next(0, width);
                int y = rand.Next(0, hight);
                if (isCell(new Point { X = x, Y = y }))
                {
                    CreateBlock(new Point { X = x, Y = y });
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
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < width; j++)
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
