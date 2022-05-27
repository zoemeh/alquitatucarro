using AlquitaTuCarro_GUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace AlquitaTuCarro_GUI.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridViewModel ViewModel { get; }

        public ContentGridPage()
        {
            ViewModel = App.GetService<ContentGridViewModel>();
            InitializeComponent();
        }
    }
}
