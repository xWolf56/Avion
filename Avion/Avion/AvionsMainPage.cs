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
	public class AvionsMainPage : ContentPage
	{
		#region Champs Privés

		Label titreLabel;

        ImageButton autopiloteImageButton;
		ImageButton commandesImageButton;
		ImageButton dateRequiseImageButton;
		ImageButton munitionsImageButton;

		Label membresLabel;

		const string MEMBRES_STR = "Dominic Robichaud\r\nJonathan Levesque\r\nMartin Chiasson-Duguay";
		#endregion

		#region Init

		public AvionsMainPage()
		{
			InitializeComponent();
		}

		#region InitializeComponent

		private void InitializeComponent()
		{
			var titreFStr = new FormattedString();
			titreFStr.Spans.Add(new Span { Text = "Avions", ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

			var membresFStr = new FormattedString();
			membresFStr.Spans.Add(new Span { Text = MEMBRES_STR, ForegroundColor = Color.White, FontSize = 30, FontAttributes = FontAttributes.Bold });

			titreLabel = new Label()
			{
				FormattedText = titreFStr,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Black
			};

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

			membresLabel = new Label()
			{
				FormattedText = membresFStr,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Black
			};

			Content = new StackLayout
			{
				Children = {
					titreLabel,
					autopiloteImageButton,
					commandesImageButton,
					dateRequiseImageButton,
					munitionsImageButton,
					membresLabel
				}
			};
		}
		#endregion

		#endregion

		#region PageSuivanteButton_Clicked

		async void PageSuivanteButton_Clicked(object sender, EventArgs e)
		{
			try
			{
				switch((sender as ImageButton).ClassId)
				{
					case "autopilote":
						await Navigation.PushAsync(new AutoPilotePage(MEMBRES_STR, "Auto Pilote"));
						break;
					case "commandes":
						await Navigation.PushAsync(new CommandesPage(MEMBRES_STR, "Munitions"));
						break;
					case "dateRequise":
						await Navigation.PushAsync(new DateRequisePage(MEMBRES_STR, "Date Requise"));
						break;
					case "munitions":
						await Navigation.PushAsync(new MunitionsPage(MEMBRES_STR, "Munitions"));
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
		#endregion
	}
}