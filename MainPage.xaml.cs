using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;


namespace MauiApp4
{
    public partial class MainPage : ContentPage
    {
        HikeDatabase hikeDatabase;

        public MainPage()
        {
            InitializeComponent();

            // Initialize the database
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbFileName = "hike.db";
            string dbPath = Path.Combine(folderPath, dbFileName);
            hikeDatabase = new HikeDatabase(dbPath);

            // Set the list view's item source to display saved hikes
            // For demonstration, we'll just set it to an empty list; you should populate it with actual data

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            hikeListView.ItemsSource = hikeDatabase.GetAllHikes();
        }


        private async void AddNewHikeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHikePage());
        }
    }
}
