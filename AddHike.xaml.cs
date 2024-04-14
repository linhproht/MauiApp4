using MauiApp4;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MauiApp4
{
    public partial class AddHikePage : ContentPage
    {
        HikeDatabase hikeDatabase;
        public AddHikePage()
        {
            InitializeComponent();
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var hike = new Hike
            {
                Name = nameEntry.Text,
                Location = locationEntry.Text,
                Date = datePicker.Date,
                ParkingAvailable = parkingSwitch.IsToggled,
                Length = lengthEntry.Text,
                DifficultyLevel = difficultyEntry.Text,
                Description = descriptionEditor.Text
            };

            var validationContext = new ValidationContext(hike, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(hike, validationContext, validationResults, true))
            {
                var errorMessage = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                await DisplayAlert("Error", errorMessage, "OK");
                return;
            }

            // Add the hike to the repository
            hikeDatabase.AddHike(hike);

            await DisplayAlert("Success", "Hike submitted successfully", "OK");

            // Clear input fields
            nameEntry.Text = string.Empty;
            locationEntry.Text = string.Empty;
            datePicker.Date = DateTime.Now;
            parkingSwitch.IsToggled = false;
            lengthEntry.Text = string.Empty;
            difficultyEntry.Text = string.Empty;
            descriptionEditor.Text = string.Empty;
        }
    }
}
