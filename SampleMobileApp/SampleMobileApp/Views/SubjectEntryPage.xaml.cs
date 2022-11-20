using System;
using System.IO;
using SampleMobileApp.Models;
using Xamarin.Forms;

namespace SampleMobileApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class SubjectEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }
        public SubjectEntryPage()
        {
            InitializeComponent();
            // Set the BindingContext of the page to a new Note.
            BindingContext = new Subject();
        }
        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Subject note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            subject.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(subject.Text))
            {
                await App.Database.SaveNoteAsync(subject);
            }
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            await App.Database.DeleteNoteAsync(subject);
            // Navigate backwards
            await Shell.Current.GoToAsync("..");

        }

    }
}