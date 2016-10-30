using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using MvvmCross.Plugins.Messenger;
using PropertyChanged;

namespace MvxPatterns.Core
{
	[ImplementPropertyChanged]
	public class CommunicationViewModel : MvxViewModel
	{
		private readonly IMvxFileStore _fileStore;

		//A IDE vai reclamar que o campo não está sendo usado, mas ele é necessário
		private readonly MvxSubscriptionToken _token;

		public CommunicationViewModel(IMvxFileStore fileStore, IMvxMessenger messenger)
		{
			_fileStore = fileStore;

			//Se inscreve para receber mensagens de um determinado tipo
			_token = messenger.Subscribe<CommunicationMessage>(OnCommunicationMessage);

			_token.Dispose();
			//Exemplo de como enviar uma mensagem. Sim, é simples assim.
			//messenger.Publish(new CommunicationMessage(this));
		}

		public void Init(CommunicationParameters parameters)
		{
			//Ler o arquivo
			string contents;
			_fileStore.TryReadTextFile(Constants.FileName, out contents);
			Value = int.Parse(contents);

			//Utilizar os parametros
			Value = parameters.SomeInteger;
		}

		public int Value { get; set; }

		private void OnCommunicationMessage(CommunicationMessage message)
		{
			//TODO: Consumir o valor
		}
	}
}
