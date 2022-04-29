/*
        Programmeurs:
                - Dominic Robichaud
                - Jonathan Levesque
                - Martin Chiasson Duguay
    
        Date: avril 2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Avion
{
	public class AutoPilotePage : ContentPage
    {
        #region Champs Prives

        Label titreLabel;
        Label autopiloteLabel;
        Label valeurAutopilotLabel;
        Label altitudeLabel;
        Label valeurAltitudeLabel;
        Label membresLabel;

        Switch autopiloteSwitch;

        Slider altitudeSlider;

        Button pagePrecedenteButton;
        #endregion

        #region Init
        public AutoPilotePage(string memberNames, string titre)
        {
            InitializeComponent(memberNames, titre);
        }

        #region InitializeComponent
        private void InitializeComponent(string memberNames, string titre)
        {
            titreLabel = new Label()
            {
                Text = titre,
                TextColor = Color.White,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            autopiloteLabel = new Label()
            {
                Text = "Activer autopilote?",
                TextColor = Color.Red,
                FontSize = 15
            };

            valeurAutopilotLabel = new Label()
            {
                TextColor = Color.LimeGreen
            };

            autopiloteSwitch = new Switch()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            altitudeLabel = new Label()
            {
                Text = "Altitude (entre 0 et 10)",
                TextColor = Color.Red,
                FontSize = 15,
            };

            valeurAltitudeLabel = new Label()
            {
                TextColor = Color.LimeGreen
            };

            altitudeSlider = new Slider()
            {
                Maximum = 10,
                Minimum = 0,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center
            };

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            membresLabel = new Label()
            {
                Text = memberNames,
                TextColor = Color.White,
                FontSize = 35,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            autopiloteSwitch.Toggled += (sender, args) => 
            { 
                valeurAutopilotLabel.Text = autopiloteSwitch.IsToggled.ToString(); 
            };

            altitudeSlider.ValueChanged += (sender, args) => 
            { 
                valeurAltitudeLabel.Text = altitudeSlider.Value.ToString(); 
            };

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
        #endregion

        #endregion

        #region PagePrecedenteButton_Clicked
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
        #endregion
    }
}