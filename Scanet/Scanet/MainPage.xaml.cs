using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Scanet;
using ZXing.Net.Mobile.Forms;
using Microsoft.WindowsAzure.MobileServices;

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

            var ScanPage = new ZXingScannerPage();
            ScanPage.AutoFocus();

            ScanPage.OnScanResult += (result) =>
            {
                Navigation.PopModalAsync();
            };
            await Navigation.PushModalAsync(ScanPage);

        }
        public static MobileServiceClient MobileService = new MobileServiceClient("https://testscanet.azurewebsites.net");
        TodoItem item = new TodoItem { Text = "Dave hit the button." };
        

        public async void OnFileClick()
        {
            await MobileService.GetTable<TodoItem>().InsertAsync(item);
            var item = MobileService.GetTable<TodoItem>().ReadAsync();
            
            fileview fileview = new fileview();
            await Navigation.PushModalAsync(fileview);
        }

    }
}
