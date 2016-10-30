using System.Threading.Tasks;

namespace AsyncTest
{
	public class TaskNotRunningInBgThread
	{
		private async Task<bool> GetSomeBoolAsync()
		{
			//Retorna uma Task<bool>
			var task = GetBoolFromSomeOtherPlaceAsync();

			//Aguarda até o fim da execução da Task, que retorna bool
			var result = await task;

			//Retorna o resultado
			return result;
		}

		private Task<bool> GetBoolFromSomeOtherPlaceAsync()
			=> Task.FromResult(false);
	}

	public static class BlockingTasks
	{
		//Esse método faz uma chamada à API e faz uma operação que consome muitos recursos da CPU.
		//Mesmo ambos os métodos sendo async, esse método bloqueia o UI thread pois os executa de forma síncrona.
		public static void DoSomething()
		{
			//Isso aqui não roda assíncrono
			var apiResult = MySuperSlowApiCallAsync().Result;

			//Nem isso
			SomeSuperHeavyProcessingAsync(apiResult).Wait();
		}

		//Esse método roda os dois sem bloquear a UI thread, do jeito que tem que ser.
		public static async Task DoSomethingAsync()
		{
			var apiResult = await MySuperSlowApiCallAsync();
			await SomeSuperHeavyProcessingAsync(apiResult);
		}

		private static async Task<string> MySuperSlowApiCallAsync()
		{
			//Aguarda por 4 segundos, simulando uma chamada de API em uma conexão fraca
			await Task.Delay(4000);
			return "It Works";
		}

		private static async Task SomeSuperHeavyProcessingAsync(string data)
		{
			//Aguarda por 10 segundos, simulando um processamento pesado em background
			await Task.Delay(10000);
			System.Diagnostics.Debug.WriteLine(data);
		}
	}
}