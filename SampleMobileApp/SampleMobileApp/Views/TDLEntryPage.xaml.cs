using System;
using System.IO;
using SampleMobileApp.Models;
using Xamarin.Forms;

namespace SampleMobileApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TDLEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public TDLEntryPage()
        {
            InitializeComponent();
            // Set the BindingContext of the page to a new Note.
            BindingContext = new TDL();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                TDL tdl = await App.Database1.GetNoteAsync(id);
                BindingContext = tdl;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var tdl = (TDL)BindingContext;
            tdl.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(tdl.Text))
            {
                await App.Database1.SaveNoteAsync(tdl);
            }
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var tdl = (TDL)BindingContext;
            await App.Database1.DeleteNoteAsync(tdl);
            // Navigate backwards
            await Shell.Current.GoToAsync("..");

        }
    }
}