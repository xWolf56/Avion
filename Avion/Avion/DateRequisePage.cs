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
        #region Déclarations

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
        #endregion

        #region Contrôles
        private void InitializeComponent(string memberNames, string titre)
        {
            #region Assignation des contrôles

            FormattedString titreFStr = new FormattedString();
            FormattedString sujetFStr = new FormattedString();
            FormattedString membresFStr = new FormattedString();

            titreFStr.Spans.Add(new Span { Text = titre, ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

            sujetFStr.Spans.Add(new Span { Text = "Sélectionner la date et l'heure requise pour la commande", ForegroundColor = Color.Red, FontSize = 15 });

            membresFStr.Spans.Add(new Span { Text = memberNames, ForegroundColor = Color.White, FontSize = 35 });

            titreLabel = new Label()
            {
                FormattedText = titreFStr,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            sujetLabel = new Label()
            {
                FormattedText = sujetFStr,
                HorizontalOptions = LayoutOptions.Center
            };

            valeurDateLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            membresLabel = new Label()
            {
                FormattedText = membresFStr,
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

            datePicker.DateSelected += (sender, args) => { valeurDateLabel.Text = $"{datePicker.Date} {timePicker.Time}"; };
            timePicker.PropertyChanged += (sender, args) => { valeurDateLabel.Text = $"{datePicker.Date} {timePicker.Time}"; };

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

        #region Navigation page suivante

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

    #endregion
    }
}