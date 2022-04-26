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
        public MunitionsPage(string memberNames, string titre)
        {
            InitializeComponent(memberNames, titre);
        }

        private void InitializeComponent(string memberNames, string titre)
        {
            var fsTitle = new FormattedString();
            var fsSubject = new FormattedString();
            var fsMemberNames = new FormattedString();

            fsTitle.Spans.Add(new Span { Text = titre, ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

            fsSubject.Spans.Add(new Span { Text = "Munitions aéronautiques", ForegroundColor = Color.Red, FontSize = 15 });

            fsMemberNames.Spans.Add(new Span { Text = memberNames, ForegroundColor = Color.White, FontSize = 35 });

            Label lblTitle = new Label()
            {
                FormattedText = fsTitle,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            Label lblSubject = new Label()
            {
                FormattedText = fsSubject,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lblMembers = new Label()
            {
                FormattedText = fsMemberNames,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black
            };

            Label pickerValue = new Label()
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
                    pagePrecedenteButton,
                    lblMembers
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