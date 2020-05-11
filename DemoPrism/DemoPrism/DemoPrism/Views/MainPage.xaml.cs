using DemoPrism.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoPrism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        MainPageViewModel model;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model = this.BindingContext as MainPageViewModel;
            
        }
    }
}