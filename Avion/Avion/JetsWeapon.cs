using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Avion
{
    public class JetsWeapon : ContentPage
    {
        public JetsWeapon(String memberNames, String titre)
        {
            var fsTitle = new FormattedString();
            var fsSubject = new FormattedString();
            var fsMemberNames = new FormattedString();

            fsTitle.Spans.Add(new Span { Text = titre, ForegroundColor = Color.White, BackgroundColor = Color.Black, FontSize = 30, FontAttributes = FontAttributes.Bold });

            fsSubject.Spans.Add(new Span { Text = "Munitions aéronautiques", ForegroundColor = Color.Red, FontSize = 15 });

            fsMemberNames.Spans.Add(new Span { Text = memberNames, ForegroundColor = Color.White, BackgroundColor = Color.Black, FontSize = 35 });

            Label lblTitle = new Label()
            {
                FormattedText = fsTitle,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lblSubject = new Label()
            {
                FormattedText = fsSubject,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lblMembers = new Label()
            {
                FormattedText = fsMemberNames,
                HorizontalOptions = LayoutOptions.Center
            };

            Label pickerValue = new Label()
            {
                HorizontalOptions = LayoutOptions.Center
            };

            Button pageSuivanteButton = new Button
            {
                Text = "Page suivante",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            pageSuivanteButton.Clicked += PageSuivanteButton_Clicked;

            Picker picker = new Picker
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

            this.Content = new StackLayout
            {
                Children =
                {
                    lblTitle,
                    lblSubject,
                    pickerValue,
                    picker,
                    pageSuivanteButton,
                    lblMembers
                }
            };

            async void PageSuivanteButton_Clicked(object sender, EventArgs e)
            {
                try
                {
                    await Navigation.PushAsync(new MainPage());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erreur", ex.ToString(), "Annuler");
                }
            }
        }
    }
}