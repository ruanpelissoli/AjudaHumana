using System.Collections.Generic;

namespace AjudaHumana.Core.ViewModels
{
    public class MenuViewModel
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Text { get; set; }

        public static List<MenuViewModel> GetMenus(string role)
        {
            return role switch
            {
                "Admin" => MenuFactory.Admin(),
                _ => MenuFactory.Default(),
            };
        }
    }    

    static class MenuFactory
    {
        public static List<MenuViewModel> Default()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = string.Empty, Controller = "Home", Action = "Index", Text = "Home" },
                new MenuViewModel { Area = string.Empty, Controller = "Home", Action = "AboutUs", Text = "Sobre Nós" },
                new MenuViewModel { Area = string.Empty, Controller = "ong", Action = "Upsert", Text = "Sou uma ONG" },
            };
        }

        public static List<MenuViewModel> Admin()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = "Admin", Controller = "ong", Action = "Index", Text = "Revisar ONGs" },
            };
        }
    }
}
