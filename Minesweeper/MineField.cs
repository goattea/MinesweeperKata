using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
	public class MineField
	{
		public int Rows { get; private set; }
		public int Columns { get; private set; }
		internal HashSet<FieldNode> Nodes { get; private set; }
		
		public MineField()
		{
			Nodes = new HashSet<FieldNode>();
		}

		public void AddRow(string input)
		{

			//Parallel.For
			for (var columnIndex = 0; columnIndex < input.Length; columnIndex++)
			{
				Nodes.Add(new FieldNode(input[columnIndex], new FieldCoordinate(Rows, columnIndex)));
			}

			Columns = input.Length;
			Rows++;
		}

		public override string ToString()
		{
			var output = new StringBuilder();
			
			ReconcileNodes();

			var currentRow = 0;

			foreach (var node in Nodes)
			{
				if (node.Coordinates.Row != currentRow)
				{
					output.Append(Environment.NewLine);
					currentRow = node.Coordinates.Row; 
				}
				output.Append(node);
			}

			output.Append(Environment.NewLine);

			return output.ToString();
		}

		private void ReconcileNodes()
		{
			var mines = Nodes
				.Where(n => n.IsMine)
				.AsParallel()
				.ToList();
			
			//Parallel.ForEach
			mines.ForEach(UpdateEmptyNodesSurroundingMine);
		}

		private void UpdateEmptyNodesSurroundingMine(FieldNode mine)
		{
			var emptyNeighbors = GetEmptyNeighbors(mine);
			emptyNeighbors.ForEach(n => n.Mines++);
		}

		private List<FieldNode> GetEmptyNeighbors(FieldNode mine)
		{
			return Nodes
				.Where(n => !n.IsMine && n.Coordinates.IsNeighboring(mine.Coordinates))
				.AsParallel()
				.ToList();
		}

	}
}
