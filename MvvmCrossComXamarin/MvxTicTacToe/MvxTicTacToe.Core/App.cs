using MvvmCross.Core.ViewModels;
using MvxTicTacToe.Core.ViewModels;

namespace MvxTicTacToe.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
			=> RegisterAppStart<MainViewModel>();
	}
}