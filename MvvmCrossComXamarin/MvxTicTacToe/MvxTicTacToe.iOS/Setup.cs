using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;

namespace MvxTicTacToe.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
			=> new Core.App();
	}
}

