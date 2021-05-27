
using Syncfusion.Licensing;

using System.Linq.Expressions;

using test.View;

using Xamarin.Forms;

namespace test {
    public partial class App : Application {

        const string key = "NDUxNzQ5QDMxMzkyZTMxMmUzMEw5R0wrSkNGVGJ3a2JDckhxWmw0NE9zN1Q0TktmNXh6THlQNk1md0srck09";
        public App() {
            
            //I will use syncfussion, to make my user interface(UI) prettier

            SyncfusionLicenseProvider.RegisterLicense(key); // Is always a goo idea to keep lines short, because is easier to the eyes
            InitializeComponent();

            MainPage = new NavigationPage(new AstedoidsCollectionPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
