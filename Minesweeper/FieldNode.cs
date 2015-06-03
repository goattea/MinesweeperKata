using System;

namespace Minesweeper
{
	internal class FieldNode : IComparable<FieldNode>
	{
		private const char MineToken = '*';
		public bool IsMine { get; private set; }
		public FieldCoordinate Coordinates { get; private set; }
		public int Mines { get; set; }
		
		public FieldNode(char nodeType, FieldCoordinate coords)
		{
			IsMine = nodeType.Equals(MineToken);
			Coordinates = coords;
		}

		public override string ToString()
		{
			return IsMine ? MineToken.ToString() : Mines.ToString();
		}

		public int CompareTo(FieldNode other)
		{
			return Coordinates.CompareTo(other.Coordinates);
		}

		public override int GetHashCode()
		{
			return Coordinates.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			var node = obj as FieldNode;
			if (node == null)
			{
				return false;
			}

			return (Coordinates == node.Coordinates);
		}

		public bool Equals(FieldNode obj)
		{
			return obj != null && Coordinates.Equals(obj.Coordinates);
		}

		public bool Equals(FieldCoordinate obj)
		{
			return obj != null && Coordinates.Equals(obj);
		}
	}
}
