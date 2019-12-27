using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    interface IViewer
    {
        void View(ICellContainer ocean, CellsCounter counter);
    }
}
