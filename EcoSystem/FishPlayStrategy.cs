using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class FishPlayStrategy
    {
        event Action<ICellContainer> Play;
        public void Invoke(ICellContainer container)
        {
            Play?.Invoke(container);
        }
        public void AddEvent(Action<ICellContainer> action)
        {
            Play += action;
        }

        public void RemoveEvent(Action<ICellContainer> action)
        {
            Play -= action;

        }
    }
}
