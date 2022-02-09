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
            totalNote.Text = "Penge Efter Skat";
            float total = 0.0f;

            Note diverseNote = new Note();
            diverseNote.Text = "Daglige frie forbrug";
            float diverse = 0.0f;

            Note indkomstNote = new Note
            {
                Text = "Indkomst"
            };
            float indkomst = 20000.0f;
            indkomstNote.Value = indkomst;

            Note fasteafgifterNote = new Note();
            fasteafgifterNote.Text = "Faste Udgifter";
            float fasteafgifter = 12000.0f;
            fasteafgifterNote.Value = fasteafgifter;

            Note gæld = new Note();
            gæld.Text = "Gæld";
            float gældvalue = 3000.0f;
            gæld.Value = gældvalue;

            Note gældfri = new Note();
            gældfri.Text = "Gældfri";
            float gældfrivalue = 5.0f;
            gældfri.Value = gældfrivalue;

            total += indkomst - fasteafgifter;
            totalNote.Value = total;

            Note mad = new Note();
            mad.Text = "Mad";
            float madvalue = 150.0f;
            mad.Value = madvalue;

            diverse += ((total / 30) - madvalue)-gældvalue/(365*gældfrivalue);
            diverseNote.Value = diverse;
            dbNotes.Add(indkomstNote);
            dbNotes.Add(fasteafgifterNote);
            dbNotes.Add(totalNote);
            dbNotes.Add(mad);
            dbNotes.Add(gæld);
            dbNotes.Add(gældfri);
            dbNotes.Add(diverseNote);
            
            
            collectionView.ItemsSource = dbNotes;
        }


        async void OnGældClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(Gæld));
        }


        /* async void OnGældClicked(object sender, SelectionChangedEventArgs e)
              {
                  if (e.CurrentSelection != null)
                  {
                      // Navigate to the NoteEntryPage, passing the ID as a query parameter.

                      await Shell.Current.GoToAsync($"{nameof(Gæld)}?{nameof(Gæld.ItemId)
                  }
              }
          }*/
    }
}