using System;

namespace EcoSystem
{
    public class Puppeteer: CellsCounter
    {
        #region fields
        
        private ICellContainer _ocean;
        private IInitializer _initializer;
        private IViewer _printer;

        #endregion

        public Puppeteer()
        {
            _ocean = new Ocean();
            _initializer = new RandomInitializer(_ocean);
            _printer = new ConsoleViewer();
        }

        public void PrintOcean()
        {
            _printer.View(_ocean,this);
        }

        public void InitOcean()
        {
            _initializer.Initialize();
        }
        
        public void Play()
        {
            _ocean.ExecuteDay();
        }

        public int Blocks { get; }

        public int Sharks { get; }

        public int Fishes { get; }
    }
}
