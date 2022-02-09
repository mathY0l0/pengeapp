using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pengeapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pengeapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class Gæld : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public Gæld()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Note();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

    }
}