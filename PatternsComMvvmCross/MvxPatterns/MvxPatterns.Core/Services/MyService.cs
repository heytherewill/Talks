using MvvmCross.Platform.Core;

namespace MvxPatterns.Core
{
	public class MyService : IMyService
	{
		public int CalculateSomeValue(int someParameter)
			=> someParameter + 1;
	}

	public class MyOtherService : MvxSingleton<IMyService>, IMyService
	{
		public int CalculateSomeValue(int someParameter)
			=> someParameter + 2;
	}
}