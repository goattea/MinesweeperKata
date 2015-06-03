using NUnit.Framework;
using Minesweeper;

namespace MinesweeperKata.UnitTests
{
	[TestFixture]
	public class FieldCoordinateTests
	{

		/*
		 
		 0,0	0,1		0,2		0,3		0,4
		 1,0	1,1		1,2		1,3		1,4
		 2,0	2,1		2,2		2,3		2,4
		 3,0	3,1		3,2		3,3		3,4
		 4,0	4,1		4,2		4,3		4,4
		 */


		[Test]
		public void When_Initialized_KnowCoordinates()
		{
			var row = 1;
			var column = 1;
			FieldCoordinate coords = new FieldCoordinate(row, column);

			Assert.AreEqual(row, coords.Row);
			Assert.AreEqual(column, coords.Column);
		}

		[Test]
		[TestCase(0, 0, 1, 1)]
		[TestCase(2, 4, 1, 3)]
		[TestCase(1, 1, 1, 2)]
		[TestCase(1, 1, 2, 2)]
		[TestCase(1, 1, 2, 1)]
		[TestCase(1, 1, 2, 0)]
		[TestCase(1, 1, 1, 0)]
		[TestCase(1, 1, 0, 0)]
		[TestCase(1, 1, 0, 1)]
		[TestCase(1, 1, 0, 2)]
		public void When_IsNeighboringAnother_IsNeghborIsTrue(int x1, int y1, int x2, int y2)
		{
			var coord1 = new FieldCoordinate(x1, y1);
			var coord2 = new FieldCoordinate(x2, y2);

			Assert.IsTrue(coord1.IsNeighboring(coord2));
		}

		[Test]
		[TestCase(2, 2, 0, 0)]
		[TestCase(2, 2, 0, 1)]
		[TestCase(2, 2, 0, 2)]
		[TestCase(2, 2, 0, 3)]
		[TestCase(2, 2, 0, 4)]
		[TestCase(2, 2, 1, 4)]
		[TestCase(2, 2, 2, 4)]
		[TestCase(2, 2, 3, 4)]
		[TestCase(2, 2, 4, 4)]
		[TestCase(2, 2, 4, 3)]
		[TestCase(2, 2, 4, 2)]
		[TestCase(2, 2, 4, 1)]
		[TestCase(2, 2, 4, 0)]
		[TestCase(2, 2, 3, 0)]
		[TestCase(2, 2, 2, 0)]
		[TestCase(2, 2, 1, 0)]
		public void When_IsNotNeighboringAnother_IsNeghborIsFalse(int x1, int y1, int x2, int y2)
		{
			var coord1 = new FieldCoordinate(x1, y1);
			var coord2 = new FieldCoordinate(x2, y2);

			Assert.IsFalse(coord1.IsNeighboring(coord2));
		}

			
	}
}
