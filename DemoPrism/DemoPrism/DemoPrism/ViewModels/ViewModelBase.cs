using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPrism.ViewModels
{
   public class ViewModelBase: BindableBase
    {
       public INavigationService navigationService;
        public ViewModelBase(INavigationService _nanigationServices)
        {
            navigationService = _nanigationServices;
        }
    }
}
