using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncTest
{
	public class SampleViewModel : INotifyPropertyChanged
	{
		public SampleViewModel()
		{
			Init = InitializeAsync();
		}

		private async Task InitializeAsync()
		{
			await Task.Delay(5000);
		}

		public Task Init { get; }

		private int _someProperty;
		public int SomeProperty
		{
			get
			{
				return _someProperty;
			}
			set
			{
				_someProperty = value;
				RaisePropertyChanged();
				SomeAsyncMethod();
			}
		}

		public IAsyncCommand SomeCommand { get; } = new AsyncCommand(() => Task.Delay(1000), true);

		private async Task SomeAsyncMethod()
		{
			await Task.Delay(1000);
		}

		protected void RaisePropertyChanged([CallerMemberName] string whichProperty = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(whichProperty));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}