using System;
namespace Infrastructure
{
    public interface IThemeService
    {
        System.Collections.Generic.List<Infrastructure.Models.Theme> GetThemes();
    }
}
