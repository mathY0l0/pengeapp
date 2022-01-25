using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pengeapp.Models;
using Xamarin.Forms;

namespace pengeapp.Views
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            List<Note> dbNotes = await App.Database.GetNotesAsync();
            Note totalNote = new Note();
            totalNote.Text = "Total";
            float total = 0.0f;
            foreach (Note note in dbNotes)
            {
                total += note.Value;
            }
            totalNote.Value = total;
            dbNotes.Add(totalNote);
            collectionView.ItemsSource = dbNotes;
        }


        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(pengeEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(pengeEntryPage)}?{nameof(pengeEntryPage.ItemId)}={note.ID.ToString()}");
            }
        }
    }
}