using AjudaHumana.Identity.Domain.ViewModels;
using System.Collections.Generic;

namespace AjudaHumana.Identity.Application.Factories
{
    public static class MenuFactory
    {
        public static List<MenuViewModel> Default()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = string.Empty, Controller = "Home", Action = "Index", Text = "Home" },
                new MenuViewModel { Area = string.Empty, Controller = "Home", Action = "AboutUs", Text = "Sobre Nós" },
                new MenuViewModel { Area = string.Empty, Controller = "Home", Action = "Upsert", Text = "Sou uma ONG" },
            };
        }

        public static List<MenuViewModel> ONG()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = "ONG", Controller = "ONG", Action = "Index", Text = "Pedidos" },
                new MenuViewModel { Area = "ONG", Controller = "ONG", Action = "Info", Text = "Informações da ONG" },
            };
        }

        public static List<MenuViewModel> Admin()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = "Admin", Controller = "Admin", Action = "Index", Text = "Revisar ONGs" },
            };
        }
    }
}
