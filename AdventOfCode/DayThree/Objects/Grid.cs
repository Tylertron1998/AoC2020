namespace DayThree.Objects
{
	public class Grid
	{
		private readonly GridType[,] _grid;

		public Grid(string[] input)
		{
			Width = input[0].Length;
			Height = input.Length;

			_grid = new GridType[Width, Height];

			for (var y = 0; y < Height; y++)
			for (var x = 0; x < Width; x++)
			{
				var line = input[y];
				var c = line[x];

				_grid[x, y] = c switch
				{
					'#' => GridType.Tree,
					'.' => GridType.Empty
				};
			}
		}

		public int Width { get; }
		public int Height { get; }

		public GridType this[int x, int y] => _grid[x % Width, y % Height];
	}
}