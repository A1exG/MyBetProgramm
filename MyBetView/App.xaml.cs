using MyBetService;
using Ninject;
using System.Windows;

namespace MyBetView
{
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IBetService>().To<BetService>();
            kernel.Bind<IGetDataService>().To<GetDataService>();
            kernel.Bind<IPayService>().To<PayService>();
            kernel.Bind<IUserValidator>().To<MyUserValidator>();
        } 
    }
}
