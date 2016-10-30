using MvvmCross.Plugins.Messenger;

namespace MvxPatterns.Core
{
	public class CommunicationMessage : MvxMessage
	{
		public int Foo { get; }

		public CommunicationMessage(object sender, int foo)
			: base(sender)
		{
			Foo = foo;
		}
	}
}
