using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using UIKit;

namespace MvxTicTacToe.iOS
{
	[Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			// Initialize app for single screen iPhone display
			var presenter = new MvxIosViewPresenter(this, Window);
			var setup = new Setup(this, presenter);
			setup.Initialize();

			// Start the app
			var start = Mvx.Resolve<IMvxAppStart>();
			start.Start();

			Window.MakeKeyAndVisible();

			return true;
		}
	}
}