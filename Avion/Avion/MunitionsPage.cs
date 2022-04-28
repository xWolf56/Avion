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
        #region Déclarations

        Label lblTitle;
        Label lblSubject;
        Label lblMembers;
        Label pickerValue;

        Picker picker;

        Button pagePrecedenteButton;
        #endregion

        #region Init

        public MunitionsPage(string memberNames, string titre)
        {
            InitializeComponent(memberNames, titre);
        }
        #endregion

        #region Contrôles
        private void InitializeComponent(string memberNames, string titre)
        {
            #region Assignation des contrôles

            var fsTitle = new FormattedString();
            var fsSubject = new FormattedString();
            var fsMemberNames = new FormattedString();

            fsTitle.Spans.Add(new Span { Text = titre, ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

            fsSubject.Spans.Add(new Span { Text = "Munitions aéronautiques", ForegroundColor = Color.Red, FontSize = 15 });

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

            pickerValue = new Label()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            picker = new Picker
            {
                Title = "Something",
                VerticalOptions = LayoutOptions.Center
            };

            var options = new List<string> { "Bombe 500 lbs", "Bombe 250 lbs", "Unites de bombe a fragmentation", "Fusees eclairantes", "Grenades fumigenes" };

            foreach (string optionName in options)
            {
                picker.Items.Add(optionName);
            }

            picker.SelectedIndexChanged += (sender, args) => { pickerValue.Text = picker.Items[picker.SelectedIndex]; };

            pagePrecedenteButton = new Button
            {
                Text = "Page precedente",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;

            this.Content = new StackLayout
            {
                Children =
                {
                    lblTitle,
                    lblSubject,
                    pickerValue,
                    picker,
                    pagePrecedenteButton,
                    lblMembers
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