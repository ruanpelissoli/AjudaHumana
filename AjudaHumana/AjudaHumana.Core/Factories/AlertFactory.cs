using AjudaHumana.Core.ViewModels;
using Newtonsoft.Json;

namespace AjudaHumana.Core.Factories
{
    public static class AlertFactory
    {
        public static string NewONGCreated()
        {
            return JsonConvert.SerializeObject(
                new AlertViewModel
                {
                    Title = "ONG cadastrada com sucesso!",
                    Message = "Iremos avaliar seu cadastro assim que possivel. Voce recebera uma e-mail com os proximos passos.",
                    Icon = "success"
                }
            );
        }
    }
}
