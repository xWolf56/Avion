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
    public class CommandesPage : ContentPage
    {
        #region Champs Prives

        Label lblTitle;
        Label lblSubject;
        Label lblMembers;
        Label lblQuantiteStr;
        Label lblPrixStr;
        Label lblPrixTotal;
        Label lblPrixTotalStr;

        Button pagePrecedenteButton;
        Button calculerButton;

        Entry quantiteAvionEntry;
        Entry prixAvionEntry;
        #endregion

        #region Init

        public CommandesPage(string memberNames, string titre)
        {
            InitializeComponent(memberNames, titre);
        }

        #region InitializeComponent
        private void InitializeComponent(string memberNames, string titre)
        {

            var fsTitle = new FormattedString();
            var fsSubject = new FormattedString();
            var fsMemberNames = new FormattedString();

            fsTitle.Spans.Add(new Span { Text = "Calculer prix avion", ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

            fsSubject.Spans.Add(new Span { Text = "Calculer une marque spécifique d'avions avec leur prix", ForegroundColor = Color.Red, FontSize = 15 });

            fsMemberNames.Spans.Add(new Span { Text = memberNames, ForegroundColor = Color.White, FontSize = 35 });

            lblTitle = new Label()
            {
                FormattedText = fsTitle,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            lblSubject = new Label()
            {
                FormattedText = fsSubject,
                HorizontalOptions = LayoutOptions.Center
            };

            lblMembers = new Label()
            {
                FormattedText = fsMemberNames,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            lblQuantiteStr = new Label
            {
                Text = "Quantite d'avions: ",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            quantiteAvionEntry = new Entry
            {
                Placeholder = "0",
                VerticalOptions = LayoutOptions.Start,
                Keyboard = Keyboard.Text
            };

            lblPrixStr = new Label
            {
                Text = "Prix par avion: ",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            prixAvionEntry = new Entry
            {
                Placeholder = "0.00",
                VerticalOptions = LayoutOptions.Start,
                Keyboard = Keyboard.Text
            };

            calculerButton = new Button
            {
                Text = "Calculer le prix",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            calculerButton.Clicked += CalculerPrixAvions_Clicked;

            lblPrixTotalStr = new Label
            {
                Text = "Prix total: ",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            lblPrixTotal = new Label
            {
                Text = "",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    lblTitle,
                    lblSubject,
                    lblQuantiteStr,
                    quantiteAvionEntry,
                    lblPrixStr,
                    prixAvionEntry,
                    calculerButton,
                    lblPrixTotalStr,
                    lblPrixTotal,
                    pagePrecedenteButton,
                    lblMembers
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

        private void CalculerPrixAvions_Clicked(object sender, EventArgs e) 
        {
            double prixTotal = (double.Parse(quantiteAvionEntry.Text) * double.Parse(prixAvionEntry.Text));

            lblPrixTotal.Text = prixTotal.ToString();

            Console.WriteLine(prixTotal);
        }
        #endregion
    }
}