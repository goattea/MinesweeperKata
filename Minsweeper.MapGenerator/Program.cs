using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minsweeper.MapGenerator
{
	static class Program
	{
		static void Main(string[] args)
		{
			var rows = int.Parse(args[0]);
			var cols = int.Parse(args[1]);
			var randomMax = int.Parse(args[2]);
			var random = new Random();

			Console.WriteLine("{0} {1}", rows, cols);

			for (var i = 0; i < rows; i++)
			{
				var row = new StringBuilder();

				for (var j = 0; j < cols; j++)
				{
					row.Append((random.Next(1, randomMax + 1)) == 1 ? "*" : ".");
				}

				Console.WriteLine(row.ToString());
			}

		}
	}
}
