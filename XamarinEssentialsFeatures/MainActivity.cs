using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Android.Net;
using System.Collections.Generic;
using System;

namespace XamarinEssentialsFeatures
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // show phone battery level
            var level = (Battery.ChargeLevel * 100).ToString() + "%";
            TextView battery = FindViewById<TextView>(Resource.Id.textView_Battery);
            battery.Text = "Battery level: " + level;

            // show app settings in phone system settings
            Button appSettingsButton = FindViewById<Button>(Resource.Id.button_Settings);
            appSettingsButton.Click += AppSettingsButton_Click;

            // open browser
            Button openBrowserButton = FindViewById<Button>(Resource.Id.button_Google);
            openBrowserButton.Click += OpenBrowser_Click;

            Button sendEmailButton = FindViewById<Button>(Resource.Id.button_Email);
            sendEmailButton.Click += SendEmailButton_Click;
        }

        private async void SendEmailButton_Click(object sender, EventArgs e)
        {
            var message = new EmailMessage();
            await Email.ComposeAsync(message);
        }

        private void AppSettingsButton_Click(object sender, System.EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }

        private void OpenBrowser_Click(object sender, System.EventArgs e)
        {
            Browser.OpenAsync("https://www.google.com");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}