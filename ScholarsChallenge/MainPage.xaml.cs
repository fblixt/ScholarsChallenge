using ScholarsChallenge.ViewModels;

namespace ScholarsChallenge
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }
    }

}
