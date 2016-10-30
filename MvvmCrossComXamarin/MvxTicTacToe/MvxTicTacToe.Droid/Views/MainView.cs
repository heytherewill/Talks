using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;

namespace MvxTicTacToe.Droid
{
	[Activity(Label = "MvxTicTacToe", Theme="@style/TicTacTheme", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainView : MvxAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainView);

			var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.MainViewRecyclerView);
			recyclerView.SetLayoutManager(new GridLayoutManager(this, 3, LinearLayoutManager.Vertical, false));
		}
	}
}