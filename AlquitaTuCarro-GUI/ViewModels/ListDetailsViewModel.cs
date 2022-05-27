﻿using System;
using System.Collections.ObjectModel;
using System.Linq;

using AlquitaTuCarro_GUI.Contracts.ViewModels;
using AlquitaTuCarro_GUI.Core.Contracts.Services;
using AlquitaTuCarro_GUI.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;

namespace AlquitaTuCarro_GUI.ViewModels
{
    public class ListDetailsViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public ListDetailsViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            SampleItems.Clear();

            // TODO: Replace with real data.
            var data = await _sampleDataService.GetListDetailsDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        public void EnsureItemSelected()
        {
            if (Selected == null)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
