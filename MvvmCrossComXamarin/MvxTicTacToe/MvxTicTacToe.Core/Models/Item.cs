using MvvmCross.Core.ViewModels;
using PropertyChanged;

namespace MvxTicTacToe.Core.Models
{
	[ImplementPropertyChanged]
	public class Item : MvxNotifyPropertyChanged
	{
		public Mark Mark { get; set; }
	}
}