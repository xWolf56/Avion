using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Avion
{
	public class AvionsMainPage : ContentPage
	{
		ImageButton autopiloteImageButton;
		ImageButton commandesImageButton;
		ImageButton dateRequiseImageButton;
		ImageButton munitionsImageButton;

		public AvionsMainPage()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			var titreFStr = new FormattedString();
			titreFStr.Spans.Add(new Span { Text = "Avions", ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

			autopiloteImageButton = new ImageButton
			{
				ClassId = "autopilote",
				Source = "Images\\autopilote.jpg",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			autopiloteImageButton.Clicked += PageSuivanteButton_Clicked;

			commandesImageButton = new ImageButton
			{
				ClassId = "commandes",
				Source = "Images\\modeles.jpg",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			commandesImageButton.Clicked += PageSuivanteButton_Clicked;

			dateRequiseImageButton = new ImageButton
			{
				ClassId = "dateRequise",
				Source = "Images\\commandes.jpg",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			dateRequiseImageButton.Clicked += PageSuivanteButton_Clicked;

			munitionsImageButton = new ImageButton
			{
				ClassId = "munitions",
				Source = "Images\\munitions.jpg",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			munitionsImageButton.Clicked += PageSuivanteButton_Clicked;

			Content = new StackLayout
			{
				Children = {
					autopiloteImageButton,
					commandesImageButton,
					dateRequiseImageButton,
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
					case "autopilote":
						await Navigation.PushAsync(new AutoPilotePage("Dominic Robichaud\r\nJonathan Levesque\r\nMartin Chiasson-Duguay", "Munitions"));
						break;
					case "commandes":
						await Navigation.PushAsync(new CommandesPage("Dominic Robichaud\r\nJonathan Levesque\r\nMartin Chiasson-Duguay", "Munitions"));
						break;
					case "dateRequise":
						await Navigation.PushAsync(new DateRequisePage("Dominic Robichaud\r\nJonathan Levesque\r\nMartin Chiasson-Duguay", "Date Requise"));
						break;
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