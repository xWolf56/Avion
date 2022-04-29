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
    public class DateRequisePage : ContentPage
    {
        #region Champs Prives

        Label titreLabel;
        Label sujetLabel;
        Label valeurDateLabel;
        Label membresLabel;

        DatePicker datePicker;
        TimePicker timePicker;

        Button pagePrecedenteButton;
        #endregion

        #region Init

        public DateRequisePage(string memberNames, string titre)
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
                Text = "Sélectionner la date et l'heure requise pour la commande",
                TextColor = Color.Red,
                FontSize = 15
            };

            valeurDateLabel = new Label()
            {
                TextColor = Color.LimeGreen
            };

            membresLabel = new Label()
            {
                Text = memberNames,
                TextColor = Color.White,
                FontSize = 35,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            datePicker = new DatePicker()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            timePicker = new TimePicker()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            datePicker.DateSelected += (sender, args) => 
            { 
                valeurDateLabel.Text = $"{datePicker.Date.ToLongDateString()} {timePicker.Time:T}"; 
            };

            timePicker.PropertyChanged += (sender, args) => 
            { 
                valeurDateLabel.Text = $"{datePicker.Date.ToLongDateString()} {timePicker.Time:T}"; 
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    sujetLabel,
                    valeurDateLabel,
                    datePicker,
                    timePicker,
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