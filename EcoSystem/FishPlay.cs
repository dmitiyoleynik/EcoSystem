using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class FishPlay
    {
        public event Action Play;
        public void Invoke()
        {
            Play?.Invoke();
        }

    }
}
