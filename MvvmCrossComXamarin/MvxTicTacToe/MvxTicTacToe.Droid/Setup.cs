using System.Linq;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace MvxTicTacToe.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp() 
			=> new Core.App();
	}
}