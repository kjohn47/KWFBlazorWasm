namespace KWFBlazorWasm.Configuration.Application.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MenuEntry : MenuOptions, IKwfAppConfigurationMenuSetup, IMenuEntry
    {
        public MenuEntry(IKwfAppConfigurationMenuEntry configuration)
        {
            this.configuration = configuration;
            this.menuList = new List<MenuLinkOptions>();
        }

        private IList<MenuLinkOptions> menuList;

        private IKwfAppConfigurationMenuEntry configuration;

        public IEnumerable<IMenuLinkOptions> MenuList { 
            get
            {
                return this.menuList;
            }
        }

        public IKwfAppConfigurationMenuSetup AddMenuLink(Action<MenuLinkOptions> options)
        {
            var menuLink = new MenuLinkOptions();
            options.Invoke(menuLink);

            if (string.IsNullOrEmpty(menuLink.Name))
            {
                throw new ArgumentNullException("Name", "Name cannot be null");
            }

            if (this.menuList.Any(x => x.Name.Equals(menuLink.Name)))
            {
                throw new ArgumentException("Menu entry name already exists", "Name");
            }

            this.menuList.Add(menuLink);
            return this;
        }

        public IKwfAppConfigurationSetup CreateMenu()
        {
            return this.configuration.AddMenuDefinition(this);
        }
    }
}
