namespace EcoSystem
{
    public class Shark : Fish
    {
        #region fields  

        protected int _currentTimeToDie;

        #endregion

        public Shark(Point p, int reproduceTime = Constants.DEFAULT_REPRODUCE_TIME,
            int dieTime = Constants.DEFAULT_DIE_TIME)
            : base(p,  reproduceTime, dieTime)
        {
            this.Icon = CellIcon.Shark;
        }

        public void EatFish(Direction dir, ICellContainer _container)
        {
            _container.KillCell(Position + dir);
            _currentTimeToDie = _timeToDie;
            Move(dir, _container);
        }

        public override void Reproduce(Direction d, ICellContainer _container)
        {
            Point newPoint = Position + d;
            if (_container.IsCell(newPoint))
            {
                Shark cell = new Shark(newPoint);
                _container.SetCell(newPoint, cell, cell.LifeCicleStep);
            }
        }

        public override void LifeCicleStep(ICellContainer _container)
        {
            _currentTime++;
            _currentTimeToDie++;
            Direction direct = RandomBehavior.GetRandomDirection();

            if (_currentTime >= _timeToDie)
            {
                Die(_container);
            }
            else
            {
                if (_container.IsFish(Position + direct))
                {
                    EatFish(direct, _container);
                }
                else if (_currentTime >= _timeToReproduce)
                {
                    _currentTime = 0;
                    Reproduce(direct, _container);
                }
                else
                {
                    Move(direct, _container);
                }
            }
        }
    }
}
