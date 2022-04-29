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

        Label titreLabel;
        Label sujetLabel;
        Label membresLabel;
        Label quantiteLabel;
        Label prixLabel;
        Label prixTotalLabel;
        Label affichagePrixTotalLabel;

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
                Text = "Calculer une marque spécifique d'avions avec leur prix",
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

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            quantiteLabel = new Label
            {
                Text = "Quantite d'avions: ",
                TextColor = Color.Red,
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            quantiteAvionEntry = new Entry
            {
                Placeholder = "0",
                TextColor = Color.LimeGreen,
                VerticalOptions = LayoutOptions.Start,
                Keyboard = Keyboard.Text
            };

            prixLabel = new Label
            {
                Text = "Prix par avion: ",
                FontSize = 12,
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            prixAvionEntry = new Entry
            {
                Placeholder = "0.00",
                TextColor = Color.LimeGreen,
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

            affichagePrixTotalLabel = new Label
            {
                Text = "Prix total: ",
                TextColor = Color.Red,
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            prixTotalLabel = new Label
            {
                Text = "",
                TextColor = Color.LimeGreen,
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    titreLabel,
                    sujetLabel,
                    quantiteLabel,
                    quantiteAvionEntry,
                    prixLabel,
                    prixAvionEntry,
                    calculerButton,
                    affichagePrixTotalLabel,
                    prixTotalLabel,
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

		#region CalculerPrixAvions_Clicked

		private async void CalculerPrixAvions_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(quantiteAvionEntry.Text, out int quantiteAvions) && double.TryParse(prixAvionEntry.Text, out double prixAvion))
                {
                    double prixTotal = quantiteAvions * prixAvion;

                    prixTotalLabel.Text = prixTotal.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annuler");
            }
        }
        #endregion
    }
}