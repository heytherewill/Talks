#define DI

using Moq;
using MvvmCross.Test.Core;
using MvxPatterns.Core;
using MvxPatterns.Core.ViewModels;
using NUnit.Framework;
using FluentAssertions;
using MvvmCross.Plugins.File;

namespace MvxPatterns.Test
{
	[TestFixture]
	public class Test : MvxIoCSupportingTest
	{
		private Mock<IMyService> _serviceMock;
		private Mock<IMvxFileStore> _fileMock;

		private DependencyViewModel _viewModel;

		[TestFixtureSetUp]
		protected void FixtureSetUp()
		{
			Setup();
			_fileMock = new Mock<IMvxFileStore>();
			_serviceMock = new Mock<IMyService>();

			#if DI
			_viewModel = new DependencyViewModel(_serviceMock.Object, _fileMock.Object);
			#else
			_viewModel = new DependencyViewModel();	
			#endif
		}

		[Test]
		public void TheViewModelStartSetsTheValueToTheReturnOfTheService()
		{
			//Arrange
			_serviceMock.Setup(s => s.CalculateSomeValue(It.IsAny<int>())).Returns(4);

			//Act
			_viewModel.Start();

			//Assert
			_viewModel.Value.Should().Be(4, "Because mock says so"); 
		}
	}
}
