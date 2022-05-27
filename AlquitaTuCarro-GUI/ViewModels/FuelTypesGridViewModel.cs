using System;
using System.Collections.ObjectModel;

using AlquitaTuCarro_GUI.Contracts.ViewModels;
using AlquitaTuCarro_GUI.Core.Contracts.Services;
using AlquitaTuCarro_GUI.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;

namespace AlquitaTuCarro_GUI.ViewModels
{
    public class FuelTypesGridViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public FuelTypesGridViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // TODO: Replace with real data.
            var data = await _sampleDataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
