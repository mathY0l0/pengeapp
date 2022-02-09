using pengeapp.Views;
using Xamarin.Forms;

namespace pengeapp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Gæld), typeof(Gæld));
        }
    }
}