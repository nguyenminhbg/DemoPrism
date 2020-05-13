using DemoPrism.IServices;
using DemoPrism.Services;
using DemoPrism.ViewModels;
using DemoPrism.Views;
using DryIoc;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace DemoPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer=null):base(initializer)
        {
           
        }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("Navigation/LoginPage");
        }
        IContainer container;
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.Register<ILoginService, LoginService>();
        }

    }
}
