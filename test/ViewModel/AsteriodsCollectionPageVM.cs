using System.Collections.ObjectModel;
using System.Windows.Input;

using test.Model;
using test.View;

using Xamarin.Forms;

namespace test.ViewModel {

    public class AsteriodsCollectionPageVM : ViewModelBase {

        //An observable collection, implements the IcllectionChanged
        public ObservableCollection<AsteroidInfo> AsteroidInfoItems { get; set; } = new ObservableCollection<AsteroidInfo>();
        public ICommand NavCommand { get; set; }
        public ICommand SelectedAsteroid { get; }

 /* Now we have two ways of grabbing the item that is tapped:
* 
* a) We can grab it directly with a command and the selected item
* b) We can pass it trough the Lambda and eliminate the selected item property
*/
        public AsteriodsCollectionPageVM() {

            AsteroidInfoItems.Add(new AsteroidInfo() {
                Date = "2019-02-22", Time = "12:01:57",
                Observatory_code = "ob_35634", Device_code = "de_10354", device_resolution = "3x7", De_matrix = "000000100100110110000"
            });
            AsteroidInfoItems.Add(new AsteroidInfo() {
                Date = "2019-02-25 ", Time = "03:24:21", Observatory_code = "ob_3482734",
                Device_code = "de_00234", device_resolution = "3x7", De_matrix = "000000010010011011000"
            });
            AsteroidInfoItems.Add(new AsteroidInfo() {
                Date = "2019-02-25 ", Time = "03:27:00", Observatory_code = "ob_3482739",
                Device_code = "de_00234", device_resolution = "3x7", De_matrix = "001011101100000000000"
            });
            AsteroidInfoItems.Add(new AsteroidInfo() {
                Date = "2019-02-26 ", Time = "03:29:00", Observatory_code = "ob_3482734",
                Device_code = "de_00765", device_resolution = "3x7", De_matrix = "000010011110010000000"
            });
            SelectedAsteroid = new Command(async (key) => {
                AsteroidInfo AsteroidInfo = key as AsteroidInfo;
                /*We could also set the binding context trough code and pass in the navigation service to this VM
                 * Also using the var keyword is not a good idea, because
                 * if you have 3000 variables in your code, the compiler have to figure out the data type
                 * of every variable
                 */
                Page app = Application.Current.MainPage;
                await app.Navigation.PushAsync(new AsteroidsDetailPage(AsteroidInfo));
            });

        }
    }
}
