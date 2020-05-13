using Autofac.Core;
using DemoPrism.IServices;
using DemoPrism.Services;
using Plugin.FacebookClient;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoPrism.ViewModels
{
 public   class LoginPageViewModel: ViewModelBase, IContainerProvider
    {
        public ICommand OnLoginWithFacebookCommand { set; get; }
       // INavigationService navigationService;
        IFacebookClient _facebookService = CrossFacebookClient.Current;
        ILoginService _loginService;
        public LoginPageViewModel(INavigationService _navigationService, ILoginService loginService) :base(_navigationService)
        {
            _loginService = loginService;
            
            OnLoginWithFacebookCommand = new DelegateCommand(LoginFaceBook);
        }

        private async void LoginFaceBook()
        {
            try
            {

                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null) return;

                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            //   _loginService.Login();
                            IContainerProviderExtensions.Resolve<ILoginService>(this).Login();
                           await  navigationService.NavigateAsync("ProfilePage");
                            //var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            //var socialLoginData = new NetworkAuthData
                            //{
                            //    Email = facebookProfile.Email,
                            //    Name = $"{facebookProfile.FirstName} {facebookProfile.LastName}",
                            //    Id = facebookProfile.UserId
                            //};
                            //   await App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                            break;
                        case FacebookActionStatus.Canceled:
                            break;
                    }

                    _facebookService.OnUserData -= userDataDelegate;
                };

                _facebookService.OnUserData += userDataDelegate;
                string[] fbRequestFields = { "email", "first_name", "gender", "last_name" };
                string[] fbPermisions = { "email" };
                await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
