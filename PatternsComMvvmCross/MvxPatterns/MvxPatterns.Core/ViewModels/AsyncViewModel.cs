using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using MvvmCross.Plugins.Messenger;
using PropertyChanged;

namespace MvxPatterns.Core.ViewModels
{
	[ImplementPropertyChanged]
    public class AsyncViewModel : MvxViewModel
    {
		private readonly Task EmptyTask = Task.FromResult(0);

		public AsyncViewModel(IMvxMessenger messenger)
		{
			//Uso de um comando que executará de forma assíncrona
			MyCommand = new MvxAsyncCommand(MyCommandExecuteAsync);

			//Inscrição para mensagens que precisam de assincronia para serem consumidas
			messenger.Subscribe<CommunicationMessage>(async message => await OnCommunicationMessage(message));
		}

		//Jeito correto de utilizar assíncronia durante a inicialização da ViewModel
		public override async void Start()
		{
			await StartAsync();
		}

		public async Task StartAsync()
		{
			await EmptyTask;
		}

		public IMvxAsyncCommand MyCommand { get; }

		public bool IsBusy { get; set; }

		private async Task MyCommandExecuteAsync()
		{
			await EmptyTask;
		}

		private async Task OnCommunicationMessage(CommunicationMessage message)
		{
			await EmptyTask;
		}
    }
}