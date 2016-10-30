using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCross.Core.ViewModels;
using MvxTicTacToe.Core.Extensions;
using MvxTicTacToe.Core.Models;
using PropertyChanged;

namespace MvxTicTacToe.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class MainViewModel : MvxViewModel
	{
		/// <summary>
		/// Generates random numbers
		/// </summary>
		private static readonly Random Random = new Random();

		/// <summary>
		/// Possible victory conditions
		/// </summary>
		private static readonly List<int[]> VictoryPositions = new List<int[]>
		{
			//Horizontal
			new [] { 0, 1, 2 },
			new [] { 3, 4, 5 },
			new [] { 6, 7, 8 },

			//Vertical
			new [] { 0, 3, 6 },
			new [] { 1, 4, 7 },
			new [] { 2, 5, 8 },

			//Diagonal
			new [] { 0, 4, 8 },
			new [] { 2, 4, 6 }
		};

		public MainViewModel()
		{
			MarkGridCommand = new MvxCommand<Item>(MarkGridCommandExecute);
		}

		/// <summary>
		/// Command called when the user selects a cell
		/// </summary>
		public IMvxCommand MarkGridCommand { get; }

		/// <summary>
		/// Method called by the MarkGridCommand
		/// </summary>
		/// <param name="mark"> Mark clicked by the user </param>
		private void MarkGridCommandExecute(Item mark)
		{
			if (mark.Mark != Mark.None) return;

			mark.Mark = Mark.X;

			if (VerifyEndOfGame()) return;

			var possibleSpots = Marks.Where(x => x.Mark == Mark.None).ToList();
			var spot = possibleSpots[Random.Next(possibleSpots.Count - 1)];
			spot.Mark = Mark.O;
				
			VerifyEndOfGame();
		}

		/// <summary>
		/// All possible marks
		/// </summary>
		public ObservableCollection<Item> Marks { get; }
			= Enumerable.Range(0, 9).Select(x => new Item()).ToObservablecCollection();


		/// <summary>
		/// Verifies whether the game ended or not.
		/// </summary>
		/// <returns> Whether the game ended or not. </returns>
		private bool VerifyEndOfGame()
		{
			var result = GameResult.NotFinished;

			var emptySpots = Marks.Count(m => m.Mark == Mark.None);
			if (emptySpots <= 5)
			{
				if (emptySpots == 0)
				{
					result = GameResult.Tie;
				}
				else
				{
					result = VerifyVictoryPermutations();
				}
			}

			switch (result)
			{
				case GameResult.O:
				case GameResult.X:
				case GameResult.Tie:
					GameOver(result);
					return true;
			}

			return false;
		}

		/// <summary>
		/// Verifies if someone won the game or not.
		/// </summary>
		/// <returns> The game output </returns>
		private GameResult VerifyVictoryPermutations()
		{
			foreach (var item in VictoryPositions)
			{
				var marks = item.Select(p => Marks[p].Mark);
				var firstMark = marks.First();

				if (marks.All(m => m == firstMark))
				{
					if (firstMark == Mark.O) return GameResult.O;
					if (firstMark == Mark.X) return GameResult.X;
				}
			}

			return GameResult.NotFinished;
		}

		/// <summary>
		/// Finishes the game and starts a new one
		/// </summary>
		/// <param name="result"> Game result </param>
		private void GameOver(GameResult result)
		{
			
			//Clears all marks
			Marks.Iter(m => m.Mark = Mark.None);

			//UserInteraction.ShowPopup("");
		}

		/// <summary>
		/// Game results, verifies after every turn.
		/// </summary>
		private enum GameResult
		{
			NotFinished,
			Tie,
			O,
			X
		}
	}
}

