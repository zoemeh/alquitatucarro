using System;

namespace AlquitaTuCarro_GUI.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
