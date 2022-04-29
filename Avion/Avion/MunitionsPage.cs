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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Avion
{
    public class MunitionsPage : ContentPage
    {
        #region Champs Prives

        Label titreLabel;
        Label sujetLabel;
        Label membresLabel;
        Label munitionSelectionneeLabel;

        Picker munitionsPicker;

        Button pagePrecedenteButton;
        #endregion

        #region Init

        public MunitionsPage(string memberNames, string titre)
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

            sujetLabel = new Label()
            {
                Text = "Munition Sélectionnée",
                TextColor = Color.Red,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };

            membresLabel = new Label()
            {
                Text = memberNames,
                TextColor = Color.White,
                FontSize = 35,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            munitionSelectionneeLabel = new Label()
            {
                TextColor = Color.LimeGreen,
                HorizontalOptions = LayoutOptions.Center
            };

            munitionsPicker = new Picker
            {
                Title = "Sélectionnez un type de munitions",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            var options = new List<string> 
            { 
                "Bombe 500 lbs", 
                "Bombe 250 lbs", 
                "Unites de bombe a fragmentation", 
                "Fusees eclairantes", 
                "Grenades fumigenes" 
            };

            foreach (string optionName in options)
            {
                munitionsPicker.Items.Add(optionName);
            }

            munitionsPicker.SelectedIndexChanged += (sender, args) => 
            { 
                munitionSelectionneeLabel.Text = munitionsPicker.Items[munitionsPicker.SelectedIndex]; 
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    sujetLabel,
                    munitionSelectionneeLabel,
                    munitionsPicker,
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