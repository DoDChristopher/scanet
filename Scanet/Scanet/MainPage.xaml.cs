using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Scanet;

namespace Scanet
{
	public partial class MainPage : ContentPage
	{
        

        public MainPage()
		{
			InitializeComponent();
            
            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            title.ScaleTo(1.3, 2000, Easing.BounceIn);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
        }

        public async void OnEnter()
        {
            await title.ScaleTo(1, 2000, Easing.BounceOut);
            
            Scanner Scanner = new Scanner();
            await Navigation.PushModalAsync(Scanner);
        }

    }
}
