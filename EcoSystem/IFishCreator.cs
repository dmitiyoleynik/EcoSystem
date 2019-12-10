using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public interface IFishCreator
    {
        void CreateFish(Point p);
        void CreateShark(Point p);
        void CreateBlock(Point p);
        bool isCell(Point p);

    }
}
