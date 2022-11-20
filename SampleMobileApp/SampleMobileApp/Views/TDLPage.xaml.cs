using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SampleMobileApp.Models;
using Xamarin.Forms;

namespace SampleMobileApp.Views
{

    public partial class TDLPage : ContentPage
    {
        public TDLPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database1.GetNotesAsync();
        }
        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(TDLEntryPage));
        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                TDL tdl = (TDL)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(TDLEntryPage)}?{nameof(TDLEntryPage.ItemId)}={tdl.tdlID.ToString()}");
            }
        }

    }
}