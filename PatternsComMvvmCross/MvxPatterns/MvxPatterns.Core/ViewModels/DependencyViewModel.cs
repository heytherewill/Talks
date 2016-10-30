#define DI

using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using PropertyChanged;

#if !DI
using MvvmCross.Platform;
#endif

namespace MvxPatterns.Core.ViewModels
{
	[ImplementPropertyChanged]
    public class DependencyViewModel : MvxViewModel
    {
		private readonly IMyService _myService;
		private readonly IMvxFileStore _fileStore;


		#if DI
		public DependencyViewModel(IMyService myService, IMvxFileStore fileStore)
		{
			_myService = myService;
			_fileStore = fileStore;

			MyCommand = new MvxCommand(MyCommandExecute);
		}
		#else
		public DependencyViewModel()
		{
			_myService = Mvx.Resolve<IMyService>();
			_fileStore = Mvx.Resolve<IMvxFileStore>();
		}
		#endif

		public IMvxCommand MyCommand { get; }

		private void MyCommandExecute()
		{
			//Escrever o valor que deve ser passado em um arquivo
			_fileStore.WriteFile(Constants.FileName, "2");

			//Passar o valor para o método init
			ShowViewModel<CommunicationViewModel>(CommunicationParameters.FromInteger(2));
		}

		public override void Start()
		{
			Value = _myService.CalculateSomeValue(2);
		}

		public int Value { get; set; }
    }
}