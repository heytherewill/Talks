using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace MvxPatterns.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
			//Registra todos os tipos cujo nome termina em Service
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
			
			Mvx.RegisterSingleton(new MyOtherService());
			Mvx.ConstructAndRegisterSingleton<IMyService, MyService>();

            RegisterAppStart<ViewModels.DependencyViewModel>();
        }
    }
}
