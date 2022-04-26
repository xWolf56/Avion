﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Avion
{
    public class DateRequisePage : ContentPage
    {
        public DateRequisePage(string memberNames, string titre)
        {
            InitializeComponent(memberNames, titre);
        }

        private void InitializeComponent(string memberNames, string titre)
        {
            FormattedString titreFStr = new FormattedString();
            FormattedString sujetFStr = new FormattedString();
            FormattedString membresFStr = new FormattedString();

            titreFStr.Spans.Add(new Span { Text = titre, ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

            sujetFStr.Spans.Add(new Span { Text = "Sélectionner la date et l'heure requise pour la commande", ForegroundColor = Color.Red, FontSize = 15 });

            membresFStr.Spans.Add(new Span { Text = memberNames, ForegroundColor = Color.White, FontSize = 35 });

            Label titreLabel = new Label()
            {
                FormattedText = titreFStr,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            Label sujetLabel = new Label()
            {
                FormattedText = sujetFStr,
                HorizontalOptions = LayoutOptions.Center
            };

            Label valeurDateLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            Label membresLabel = new Label()
            {
                FormattedText = membresFStr,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            DatePicker datePicker = new DatePicker()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            TimePicker timePicker = new TimePicker()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            Button pagePrecedenteButton = new Button
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