using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MvxTicTacToe.Core.Extensions
{
	public static class EnumerableExtensions
	{
		public static void Iter<T>(this IEnumerable<T> self, Action<T> action)
		{
			foreach (var item in self)
			{
				action?.Invoke(item);
			}
		}

		public static ObservableCollection<T> ToObservablecCollection<T>(this IEnumerable<T> self)
			=> new ObservableCollection<T>(self);
	}
}