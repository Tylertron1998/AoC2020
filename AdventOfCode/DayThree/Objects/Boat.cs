namespace DayThree.Objects
{
    public class Boat
    {

        public bool HasFinished => _y >= _grid.Height;
        public bool HasEncounteredTree => _grid[_x, _y] == GridType.Tree;
        
        private Grid _grid;
        private int _downStride;
        private int _rightStride;

        private int _x;
        private int _y;

        public Boat(Grid grid, int downStride = 1, int rightStride = 3)
        {
            _grid = grid;
            _downStride = downStride;
            _rightStride = rightStride;
        }

        public void Stride()
        {
            _x += _rightStride;
            _y += _downStride;
        }
    }
}