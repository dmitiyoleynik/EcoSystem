namespace EcoSystem
{
    class Puppeteer
    {
        #region variables 
        private Ocean _ocean;
        private IInitializer _initializer;
        private IPrinter _printer;
        private FishPlay _fishPlay;
        #endregion

        public Puppeteer()
        {
            _ocean = new Ocean();
            _initializer = new RandomInitializer(_ocean);
            _printer = new Printer();
            _fishPlay = new FishPlay();
            FishManager.SetFishPlay(_fishPlay);
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
