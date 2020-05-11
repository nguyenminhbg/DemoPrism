using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoPrism.ViewModels
{
  public  class MainPageViewModel : BindableBase
    {
        private string title;
        public string Title
        {
            get => title;
            set { SetProperty(ref title, value); }
        }
        public ICommand NextCmd { set; get; }
        INavigationService navigationService;
        public MainPageViewModel(INavigationService _navigationService)
        {
            navigationService = _navigationService;
            Title = "Anh Minh đẹp zai vãi nhái";
            NextCmd = new DelegateCommand(NextProfile);
        }

        private void NextProfile()
        {
            navigationService.NavigateAsync("ProfilePage");
        }
    }
}
