using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class FishPlayStrategy
    {
        public event Action<ICellContainer> Play;
        public void Invoke(ICellContainer container)
        {
            Play?.Invoke(container);
        }
        public void AddEvent()
        {

        }

        public void RemoveEvent()
        {

        }
    }
}
