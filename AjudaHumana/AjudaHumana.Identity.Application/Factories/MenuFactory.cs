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
                new MenuViewModel { Area = string.Empty, Controller = "ong", Action = "Upsert", Text = "Sou uma ONG" },
            };
        }

        public static List<MenuViewModel> ONG()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = "ONG", Controller = "Order", Action = "Index", Text = "Pedidos" },
                new MenuViewModel { Area = "ONG", Controller = "Order", Action = "Index", Text = "Cadastrar Pedido" },
                new MenuViewModel { Area = "ONG", Controller = "Order", Action = "Index", Text = "Informações da ONG" },
            };
        }

        public static List<MenuViewModel> Admin()
        {
            return new List<MenuViewModel>
            {
                new MenuViewModel { Area = "Admin", Controller = "ONG", Action = "Index", Text = "Revisar ONGs" },
            };
        }
    }
}
