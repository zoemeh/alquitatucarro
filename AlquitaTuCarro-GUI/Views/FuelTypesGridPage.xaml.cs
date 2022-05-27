using AlquitaTuCarro_GUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace AlquitaTuCarro_GUI.Views
{
    // TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
    // For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
    public sealed partial class FuelTypesGridPage : Page
    {
        public FuelTypesGridViewModel ViewModel { get; }

        public FuelTypesGridPage()
        {
            ViewModel = App.GetService<FuelTypesGridViewModel>();
            InitializeComponent();
        }
    }
}
