using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public interface IInitializer
    {
        void Initialize(Cell[,] cells,int widthRange,int higthRange);
    }
}
