using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace DarkMatter.Theme.Maqui
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "DarkMatter Maqui",
            Version = "1.0.0",
            PackageName = "DarkMatter.Theme.Maqui",
            ThemeSettingsType = "DarkMatter.Theme.Maqui.ThemeSettings, DarkMatter.Theme.Maqui.Client.Oqtane",
            ContainerSettingsType = "DarkMatter.Theme.Maqui.ContainerSettings, DarkMatter.Theme.Maqui.Client.Oqtane",
            Resources = new List<Resource>()
            {
		        // obtained from https://www.mudblazor.com/getting-started/installation#manual-install-add-script-reference

                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/_content/MudBlazor/MudBlazor.min.css" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css" },
                new Resource { ResourceType = ResourceType.Script, Url = "~/_content/MudBlazor/MudBlazor.min.js", Level=ResourceLevel.Site }
            }
        };

    }
}
