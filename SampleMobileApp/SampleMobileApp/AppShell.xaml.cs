using SampleMobileApp.Views;
using Xamarin.Forms;
namespace SampleMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SubjectEntryPage), typeof(SubjectEntryPage));
            Routing.RegisterRoute(nameof(TDLEntryPage), typeof(TDLEntryPage));
        }
    }
}
