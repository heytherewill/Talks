using System;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvxPatterns.Core.ViewModels;

namespace MvxPatterns.Core.Extensions
{
	public static class TaskExtensions
	{
		public static async Task WithBusyIndicator(this Task self, AsyncViewModel vm = null)
		{
			if (vm != null) vm.IsBusy = true;

			try
			{
				await self.ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				//TODO: Tratar erro
				Mvx.Trace(MvxTraceLevel.Error, ex.Message);
			}
			finally
			{
				if (vm != null) vm.IsBusy = false;
			}
		}

		public static async Task<T> WithBusyIndicator<T>(this Task<T> self, AsyncViewModel vm = null)
		{
			if (vm != null) vm.IsBusy = true;

			try
			{
				return await self.ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				//TODO: Tratar erro
				Mvx.Trace(MvxTraceLevel.Error, ex.Message);
				return default(T);
			}
			finally
			{
				if (vm != null) vm.IsBusy = false;
			}
		}
	}
}