using System;

namespace Minesweeper
{
	internal class FieldCoordinate : IComparable<FieldCoordinate>
	{

		public FieldCoordinate(int row, int column)
		{
			Row = row;
			Column = column;
		}

		public int Row { get; private set; }
		public int Column { get; private set; }

		internal bool IsNeighboring(FieldCoordinate other)
		{
			var horizontalDistance = Math.Abs(Row - other.Row);
			var verticalDistance = Math.Abs(Column - other.Column);

			return horizontalDistance <= 1 && verticalDistance <= 1;
		}

		public int CompareTo(FieldCoordinate other)
		{
			if (Row == other.Row && Column == other.Column)
				return 0;

			return Row != other.Row ? 
				Row.CompareTo(other.Row) : 
				Column.CompareTo(other.Column);
		}

		public override int GetHashCode()
		{
			return Row * 10000 + Column;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			var coord = obj as FieldCoordinate;
			if (coord == null)
			{
				return false;
			}

			return (Row == coord.Row) && (Column == coord.Column);
		}

		public bool Equals(FieldCoordinate obj)
		{
			if (obj == null)
			{
				return false;
			}

			return (Row == obj.Row) && (Column == obj.Column);
		}
	}
}
