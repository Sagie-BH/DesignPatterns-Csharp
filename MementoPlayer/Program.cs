using System;
using System.Collections.Generic;
using System.Linq;

namespace MementoPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
			var player = new Player();

			player.GoForward();
			player.GoForward();
			player.GoForward();
			player.GoBack();
			player.GoBack();
			player.GoForward();
			player.GoForward();
			player.GoBack();
		}
    }
	public class Player
	{
		List<Position> positionMemory = new List<Position>();
		Position.Piece piece = new Position.Piece();

		public void GoForward()
		{
			// roll dice
			var position = piece.GetPosition();
			// save the position into the memory
			positionMemory.Add(position);

			int n = new Random().Next(1, 6);
			piece.Move(n);
		}

		public void GoBack()
		{
			// we take the last memory
			var position = positionMemory.Last();
			// delete it from memory
			positionMemory.Remove(position);
			// setting new position
			piece.SetPosition(position);
		}
	}
	// The Memento Describes The State
	public struct Position
	{
		private int Cell { get; set; }

		// How to preserve the state without exposing
		public class Piece
        {
			// Current state - still able to change the state
            public Position _position = new Position() { Cell = 0 }; // Statring At
			// to move forward we add to position
            public void Move(int n) => _position.Cell += n; // Moving To

			public Position GetPosition() => new Position { Cell = _position.Cell };

            public void SetPosition(Position p) => _position.Cell = p.Cell; // Going Back To
		}

    }
}
