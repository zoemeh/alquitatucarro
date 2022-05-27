using System;
using System.Linq;

using AlquitaTuCarro_GUI.Contracts.ViewModels;
using AlquitaTuCarro_GUI.Core.Contracts.Services;
using AlquitaTuCarro_GUI.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;

namespace AlquitaTuCarro_GUI.ViewModels
{
    public class ContentGridDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public ContentGridDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is long orderID)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First(i => i.OrderID == orderID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
