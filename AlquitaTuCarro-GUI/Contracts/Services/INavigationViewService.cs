﻿using System;
using System.Collections.Generic;

using Microsoft.UI.Xaml.Controls;

namespace AlquitaTuCarro_GUI.Contracts.Services
{
    public interface INavigationViewService
    {
        IList<object> MenuItems { get; }

        object SettingsItem { get; }

        void Initialize(NavigationView navigationView);

        void UnregisterEvents();

        NavigationViewItem GetSelectedItem(Type pageType);
    }
}
