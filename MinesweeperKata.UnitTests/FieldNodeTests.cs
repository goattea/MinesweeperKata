using Minesweeper;
using NUnit.Framework;

namespace MinesweeperKata.UnitTests
{
	[TestFixture]
	public class FieldNodeTests
	{
		[Test]
		public void When_NodeInitiatedWithMineToken_IsMineIsTrue()
		{
			var coords = new FieldCoordinate( 0, 0);
			FieldNode node = new FieldNode('*', coords);

			Assert.IsTrue(node.IsMine);

		}

		[Test]
		public void When_NodeInitiatedWithCoordinates_ExposesReadOnlyCoordinates()
		{
			var tokenType = '*';
			var x = 1;
			var y = 1;
			
			var coords = new FieldCoordinate(x, y);
			
			FieldNode node = new FieldNode(tokenType, coords);

			Assert.AreEqual(x, node.Coordinates.Row);
			Assert.AreEqual(y, node.Coordinates.Column);
		}

		[Test]
		public void When_NodeIsAMine_ToStringIsAsterisk()
		{
			var tokenType = '*';
			FieldNode node = new FieldNode(tokenType, new FieldCoordinate(0, 0));

			Assert.AreEqual("*", node.ToString());
		}

		[Test]
		public void When_NodeIsNotAMine_ToStringIsNumber()
		{
			var tokenType = '.';
			int result;

			FieldNode node = new FieldNode(tokenType, new FieldCoordinate(0, 0));

			Assert.IsTrue(int.TryParse(node.ToString(), out result));
		}

		[Test]
		[TestCase(0)]
		[TestCase(8)]
		public void When_NodeIsNotAMine_ToStringIsNumberOfMines(int result)
		{
			var tokenType = '.';

			FieldNode node = new FieldNode(tokenType, new FieldCoordinate(0, 0));
			node.Mines = result;

			Assert.AreEqual(result.ToString(), node.ToString());
		}

	}
}
