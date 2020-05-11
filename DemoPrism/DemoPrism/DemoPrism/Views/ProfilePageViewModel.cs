using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPrism.Views
{
  public  class ProfilePageViewModel:INavigatedAware
    {
        IPageDialogService _dialogService;
        INavigationService navigationService;
        public ProfilePageViewModel(INavigationService _navigationService,IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            navigationService = _navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
           // _dialogService.DisplayAlertAsync("Check", "This is Notication to noty team member", "Ok");
            navigationService.NavigateAsync("DetailPage");
        }
    }
}
