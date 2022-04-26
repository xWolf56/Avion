using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Avion
{
	public class AvionsMainPage : ContentPage
	{
		public AvionsMainPage()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			var fsTitle = new FormattedString(); 
			fsTitle.Spans.Add(new Span { Text = "Avions", ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

			ImageButton munitionsImageButton = new ImageButton
			{
				ClassId = "munitions",
				Source = "munitions.jpg",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			munitionsImageButton.Clicked += PageSuivanteButton_Clicked;

			Content = new StackLayout
			{
				Children = {
					munitionsImageButton
				}
			};
		}

		async void PageSuivanteButton_Clicked(object sender, EventArgs e)
		{
			try
			{
				switch((sender as ImageButton).ClassId)
				{
					case "munitions":
						await Navigation.PushAsync(new MunitionsPage("Dominic Robichaud\r\nJonathan Levesque\r\nMartin Chiasson-Duguay", "Munitions"));
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Erreur", ex.ToString(), "Annuler");
			}
		}
	}
}