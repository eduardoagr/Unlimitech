
using test.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsteroidsDetailPage : ContentPage {
        public AsteroidsDetailPage(AsteroidInfo asteroidInfo) {
            InitializeComponent();

            /*since we require to do a matrix dynamically, based on the matrix coming from the model, we are going to do the matrix in code,
             * probably there is an easier way to do this, we could use SkiaSharp or maybe we could do a 3x7 matrix in xaml and make an if,
             * to ask if we have a 0 or 1 and paint it
             */

            //device_resolution you have de_matrix
            //2019 - 02 - 22 12:01:57 ob_35634 de_10354
            //device_resolution 3x7 
            //  de_matrix 000 000 100 100 110 110 000

            Grid MyGrid = new Grid {
                Margin = 10,
                BackgroundColor = Color.Black,
            };


            RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();
            ColumnDefinitionCollection columnDefinitions = new ColumnDefinitionCollection();

            string[] words = asteroidInfo.device_resolution.Split('x');
            int RowNum = int.Parse(words[1]);
            int ColumnNum = int.Parse(words[0]);

            for (int i = 0; i < RowNum; i++) {
                rowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < ColumnNum; i++) {
                columnDefinitions.Add(new ColumnDefinition());
            }
            MyGrid.RowDefinitions = rowDefinitions;
            MyGrid.ColumnDefinitions = columnDefinitions;

            //Create a 2d array
            int[,] a = new int[RowNum, ColumnNum];

            string testStr = asteroidInfo.De_matrix;

            char[] StrCharArray = testStr.ToCharArray();

            for (int i = 0; i < RowNum; i++) {  //0(N^2) TIME COMPLEXITY
                for (int j = 0; j < ColumnNum; j++) {
                    a[i, j] = StrCharArray[i * 3 + j];
                }
            }
            //According to the value of 1 or 0, to change the  boxview's background color.
            for (int i = 0; i < RowNum; i++) {
                for (int j = 0; j < ColumnNum; j++) { // 0(N^2)
                    BoxView boxView = new BoxView {
                        BackgroundColor = StrCharArray[i * 3 + j].ToString().Equals("0") ? Color.White : Color.Black
                    };
                    MyGrid.Children.Add(boxView, j, i);
                }
            }
            StackLayout stackLayout = new StackLayout { BackgroundColor = Color.LavenderBlush, Margin = 10 };
            Label dateTime = new Label { Text = $"{asteroidInfo.Date}-{asteroidInfo.Time}", FontAttributes = FontAttributes.Bold, FontSize = 18 };
            Label codes = new Label { Text = $"Observatory code: {asteroidInfo.Observatory_code}\nDevice code: {asteroidInfo.Device_code}" };
            Label res = new Label { Text = $"Device resolution: {asteroidInfo.device_resolution}" };
            Label matrix = new Label {
                Text = $"Matrix: {asteroidInfo.De_matrix}"
            };

            stackLayout.Children.Add(dateTime);
            stackLayout.Children.Add(codes);
            stackLayout.Children.Add(res);
            stackLayout.Children.Add(matrix);
            stackLayout.Children.Add(MyGrid);
            Content = stackLayout;
        }
    }
}