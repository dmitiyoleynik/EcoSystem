using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public interface IFishManager
    {
        void CreateFish(Point p);
        void CreateShark(Point p);
        void CreateBlock(Point p);
        bool isCell(Point p);
        bool isFish(Point p);
        bool isShark(Point p);
        bool isBlock(Point p);
        void ClearOcean();
        void KillCell(Point p);
        void SwopCell(Point p1, Point p2);
        int FishNumber { get; }

        int SharkNumber { get; }

        int BlocksNumber { get; }
    }
}
