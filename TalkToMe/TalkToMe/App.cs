using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Refractored.Xam.TTS;
using Geolocator.Plugin;

namespace TalkToMe
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var btnTalk = new Button();

            var lblLocation = new Label();

            btnTalk.Text = "Talk to me";
            btnTalk.BackgroundColor = Color.Gray;
            btnTalk.TextColor = Color.Green;

            btnTalk.Clicked += async (sender, args) =>
            {
                //lblLocation.Text = "You clicked?";

                CrossTextToSpeech.Current.Speak("You have been rerouted through the Lincoln Tunnel.");

                var location = CrossGeolocator.Current;

                var position = await location.GetPositionAsync(timeout: 10000);

                lblLocation.Text = $"Lat: {position.Latitude} Long: {position.Longitude}";
            };

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        btnTalk,
                        lblLocation
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
