using System.Globalization;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;
using MvxTicTacToe.Core.Models;

namespace MvxTicTacToe.Core.Converters
{
	public class MarkColorConverter : MvxColorValueConverter<Mark>
	{
		protected override MvxColor Convert(Mark value, object parameter, CultureInfo culture)
		{
			switch (value)
			{
				case Mark.O:
					return MvxColors.Blue;
				case Mark.X:
					return MvxColors.Red;
				default:
					return MvxColors.Transparent;
			}
		}
	}
}