using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace AsyncTest
{
	[Activity(Label = "AsyncTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var blockingButton = FindViewById<Button>(Resource.Id.BlockingButton);
			var nonBlockingButton = FindViewById<Button>(Resource.Id.NonBlockingButton);
			blockingButton.Click += BlockingButtonClick;
			nonBlockingButton.Click += NonBlockingButtonClick;
		}

		private void BlockingButtonClick(object sender, EventArgs e)
			=> BlockingTasks.DoSomething();

		private async void NonBlockingButtonClick(object sender, EventArgs e)
			=> await BlockingTasks.DoSomethingAsync();
	}
}