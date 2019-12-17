using System;

namespace EcoSystem
{
    public class Puppeteer
    {
        #region fields
        
        private Ocean _ocean;
        private IInitializer _initializer;
        private IPrinter _printer;

        private FishPlay _fishPlay;

        #endregion

        public Puppeteer()
        {
            _fishPlay = new FishPlay();
            _ocean = new Ocean(_fishPlay);
            _initializer = new RandomInitializer(_ocean);
            _printer = new Printer();
        }

        public void PrintOcean()
        {
            _printer.Print(_ocean);
        }

        public void InitOcean()
        {
            _initializer.Initialize(_ocean.Width, _ocean.Hight);
        }
        
        public void Play()
        {
            _fishPlay.Invoke();
        }

    }
}
