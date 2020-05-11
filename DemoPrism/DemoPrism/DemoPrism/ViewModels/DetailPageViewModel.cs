﻿using Prism.Navigation;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrism.ViewModels
{
    public class DetailPageViewModel : INavigatedAware
    {
        INavigationService navigationService;
        public DetailPageViewModel(INavigationService _navigationService)
        {
            navigationService = _navigationService;
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
           await Task.Delay(3000);
            navigationService.GoBackToRootAsync();
        }
    }
}
