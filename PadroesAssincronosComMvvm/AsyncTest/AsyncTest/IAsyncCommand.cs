using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncTest
{
	public interface IAsyncCommand : ICommand
	{
		Task ExecuteAsync(object param = null);
	}

	public class AsyncCommand : IAsyncCommand
	{
		private readonly bool _canExecute;
		private readonly Func<Task> _action;

		public AsyncCommand(Func<Task> action, bool canExecute)
		{
			_action = action;
			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
			=> _canExecute;

		public void Execute(object parameter)
		{
			_action?.Invoke();
		}

		public async Task ExecuteAsync(object param = null)
		{
			await _action?.Invoke();
		}
	}
}

