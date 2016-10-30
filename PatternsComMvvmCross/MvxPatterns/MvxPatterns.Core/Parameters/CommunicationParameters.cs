using System;
namespace MvxPatterns.Core
{
	public class CommunicationParameters
	{
		public int SomeInteger { get; set; }

		public static CommunicationParameters FromInteger(int someInteger)
			=> new CommunicationParameters { SomeInteger = someInteger };
	}
}