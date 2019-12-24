using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public interface ICellContainer
    {
        bool IsCell(Point p);
        bool IsFish(Point p);
        void CreateFish(Point p);
        void CreateShark(Point p);
        void SwopCell(Point p1, Point p2);
        void KillCell(Point p);
    }
}
