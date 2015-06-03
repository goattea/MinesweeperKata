using System;
using System.Collections.Generic;
using Minesweeper;

namespace Minsweeper.ConsoleApp
{
	static class Program
	{
		static void Main()
		{
			var fields = new List<MineField>();

			while (true)
			{
				var input = Console.ReadLine();
				if (input == "0 0" || input == null) 
					break;

				var rows = int.Parse(input.Split(' ')[0]);
				var field = new MineField();

				for (var i = 0; i < rows; i++)
				{
					var row = Console.ReadLine();
					field.AddRow(row);
				}

				fields.Add(field);
			}

			for (var i = 0; i < fields.Count; i++)
			{
				Console.WriteLine("Field #{0}:", i + 1);
				Console.WriteLine(fields[i].ToString());
			}

			Console.ReadLine();
		}
	}
}
