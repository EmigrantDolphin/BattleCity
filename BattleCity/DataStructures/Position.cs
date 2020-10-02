namespace BattleCity.DataStructures
{
    public class Position
    {
        private int _curX;
        private int _curY;
        public int CurX { 
            get 
            { 
                return _curX; 
            } 
            set 
            {
                PrevX = _curX;
                PrevY = _curY;
                _curX = value;
            } 
        }
        public int CurY 
        { 
            get
            {
                return _curY;
            }
            set
            {
                PrevY = _curY;
                PrevX = _curX;
                _curY = value;
            }
        }
        public int PrevX { get; private set; }
        public int PrevY { get; private set; }
        public void MoveToPrevious()
        {
            _curX = PrevX;
            _curY = PrevY;
        }
    }
}
