using AlquitaTuCarro_GUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace AlquitaTuCarro_GUI.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            ViewModel = App.GetService<MainViewModel>();
            InitializeComponent();
        }
    }
}
