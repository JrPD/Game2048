using System;
using System.Linq;

namespace Game2048
{
	public interface ICellGenerator
	{
		void Generate(CellArray board);
	}

	public class CellGenerator : ICellGenerator
	{
		public CellGenerator()
		{
		}

		public void Generate(CellArray board)
		{
			var rnd = new Random();

			var empty = board.GetEmpty();
			var newCellCount = rnd.Next(1, 2);

			for (int i = 0; i < newCellCount; i++)
			{
				var newCell = rnd.Next(0, empty.Count() - 1);
				var newValue = rnd.Next(0, 1) == 0 ? 2 : 4;

				empty.ElementAt(newCell).Value = newValue;
			}
		}
	}
}