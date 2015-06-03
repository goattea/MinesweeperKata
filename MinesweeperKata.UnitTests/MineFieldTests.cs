using System;
using System.Linq;
using NUnit.Framework;
using Minesweeper;

namespace MinesweeperKata.UnitTests
{
	[TestFixture]
	public class MineFieldTests
	{

		private const char mineToken = '*';
		private const char emptyToken = '.';

		[Test]
		public void When_Instantiated_ObjectCreated()
		{
		
			MineField field = new MineField();

			Assert.IsNotNull(field);
		}

		[Test]
		public void When_RowIsAdded_AddsNodes()
		{
			MineField field = new MineField();

			field.AddRow(".....");

			Assert.IsTrue(field.Nodes.Count > 0);
		}

		[Test]
		public void When_RowIsAdded_RowAndColumnsSetBasedOnRow()
		{
			var newRow = ".....";
			MineField field = new MineField();

			field.AddRow(newRow);

			Assert.AreEqual(1, field.Rows);
			Assert.AreEqual(newRow.Length, field.Columns);

		}

		[Test]
		public void When_TwoRowsAdded_RowAndColumnsSetBasedOnRow()
		{
			var newRow = ".....*";
			MineField field = new MineField();

			field.AddRow(newRow);
			field.AddRow(newRow);

			Assert.AreEqual(2, field.Rows);
			Assert.AreEqual(newRow.Length, field.Columns);
		}

		[Test]
		public void When_RowIsAdded_AddsNodePerCharacter()
		{
			var newRow = ".....*";
			MineField field = new MineField();

			field.AddRow(newRow);

			Assert.AreEqual(newRow.Length, field.Nodes.Count);
		}

		[Test]
		public void When_RowIsAdded_NodesThatAreMinesCanBeCounted()
		{
			var newRow = ".*";
			MineField field = new MineField();

			field.AddRow(newRow);

			Assert.AreEqual(1, field.Nodes.Count(m => m.IsMine));
		}

		[Test]
		public void When_RowIsAdded_NodesThatAreNotMinesCanBeCounted()
		{
			var mines = 2;
			var empty = 3;

			var newRow = new String(mineToken, mines) + new String(emptyToken, empty);
			MineField field = new MineField();

			field.AddRow(newRow);
			Assert.AreEqual(empty, field.Nodes.Count(m => !m.IsMine));
		}

		[Test]
		public void When_RowIsAdded_NodesHaveCorrectCoordinates()
		{
			var newRow = ".*";
			var emptyCoords = new FieldCoordinate(0, 0);
			var mineCoords = new FieldCoordinate(0, 1);

			MineField field = new MineField();

			field.AddRow(newRow);

			var emptiesHaveSameCoords = field.Nodes.Single(m => !m.IsMine).Coordinates.CompareTo(emptyCoords) == 0;
			var minesHaveSameCoords = field.Nodes.Single(m => m.IsMine).Coordinates.CompareTo(mineCoords) == 0;

			Assert.IsTrue(emptiesHaveSameCoords && minesHaveSameCoords);
		}

		[Test]
		[TestCase(".", "0\r\n")]
		[TestCase("*", "*\r\n")]
		[TestCase("..", "00\r\n")]
		[TestCase("**", "**\r\n")]
		[TestCase(".*", "1*\r\n")]
		[TestCase(".*.", "1*1\r\n")]
		[TestCase("*.*", "*2*\r\n")]
		public void When_SimpleFieldIsRequested_ReturnsCorrectFormat(string row, string expectedField)
		{
			MineField field = new MineField();

			field.AddRow(row);

			Assert.AreEqual(expectedField, field.ToString());
		}

		[Test]
		[TestCase(new[] { ".", "." }, new[] { "0\r\n", "0\r\n" })]
		[TestCase(new[] { "*...", "....", ".*..", "...." }, new[] { "*100\r\n", "2210\r\n", "1*10\r\n", "1110\r\n" })]
		[TestCase(new[] { "**...", ".....", ".*..." }, new[] { "**100\r\n", "33200\r\n", "1*100\r\n" })]
		public void When_MultiRowFieldIsRequested_ReturnsCorrectFormat(string[] rows, string[] expectedFieldRows)
		{
			MineField field = new MineField();
			foreach (var row in rows)
			{
				field.AddRow(row);
			}

			Assert.AreEqual(string.Concat(expectedFieldRows), field.ToString());
		}

	}
}
