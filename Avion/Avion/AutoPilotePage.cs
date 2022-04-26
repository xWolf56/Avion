using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Avion
{
	public class AutoPilotePage : ContentPage
    {
        Label titreLabel;
        Label autopiloteLabel;
        Label valeurAutopilotLabel;
        Label altitudeLabel;
        Label valeurAltitudeLabel;
        Label membresLabel;

        Switch autopiloteSwitch;

        Slider altitudeSlider;

        Button pagePrecedenteButton;

        public AutoPilotePage(string memberNames, string titre)
        {
            InitializeComponent(memberNames, titre);
        }

        private void InitializeComponent(string memberNames, string titre)
        {
            var TitreFStr = new FormattedString();
            var autopiloteFStr = new FormattedString();
            var altitudeFStr = new FormattedString();
            var membresFStr = new FormattedString();

            TitreFStr.Spans.Add(new Span { Text = titre, ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

            autopiloteFStr.Spans.Add(new Span { Text = "Activer autipilote?", ForegroundColor = Color.Red, FontSize = 15 });

            altitudeFStr.Spans.Add(new Span { Text = "Altitude (entre 0 et 10)", ForegroundColor = Color.Red, FontSize = 15 });

            membresFStr.Spans.Add(new Span { Text = memberNames, ForegroundColor = Color.White, FontSize = 35 });

            titreLabel = new Label()
            {
                FormattedText = TitreFStr,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            autopiloteLabel = new Label()
            {
                FormattedText = autopiloteFStr,
                HorizontalOptions = LayoutOptions.Center
            };

            valeurAutopilotLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            autopiloteSwitch = new Switch();

            altitudeLabel = new Label()
            {
                FormattedText = altitudeFStr,
                HorizontalOptions = LayoutOptions.Center
            };

            valeurAltitudeLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            altitudeSlider = new Slider()
            {
                Maximum = 10,
                Minimum = 0
            };

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            membresLabel = new Label()
            {
                FormattedText = membresFStr,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            autopiloteSwitch.Toggled += (sender, args) => { valeurAutopilotLabel.Text = autopiloteSwitch.IsToggled.ToString(); };
            altitudeSlider.ValueChanged += (sender, args) => { valeurAltitudeLabel.Text = altitudeSlider.Value.ToString(); };

            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    autopiloteLabel,
                    valeurAutopilotLabel,
                    autopiloteSwitch,
                    altitudeLabel,
                    valeurAltitudeLabel,
                    altitudeSlider,
                    pagePrecedenteButton,
                    membresLabel
                }
            };
        }

        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annuler");
            }
        }
    }
}