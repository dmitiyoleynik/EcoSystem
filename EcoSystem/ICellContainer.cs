using System;

namespace EcoSystem
{
    public interface ICellContainer
    {
        bool IsCell(Point p);

        bool IsFish(Point p);

        void SetCell(Point p,Cell cell,Action<ICellContainer> act);
        
        void SwopCell(Point p1, Point p2);
        
        void KillCell(Point p);

        int Hight { get; }
        
        int Width { get; }

        public CellIcon this[int x, int y] { get; }

        void ExecuteDay();

    }
}
