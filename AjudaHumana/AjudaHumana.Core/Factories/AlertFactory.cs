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

        public static string NewONGApproved()
        {
            return JsonConvert.SerializeObject(
                new AlertViewModel
                {
                    Title = "ONG aprovada!",
                    Message = "Parabéns! Mais uma ONG vou aprovada para fazer parte do Ajuda Humana.",
                    Icon = "success"
                }
            );
        }

        public static string NewONGReproved()
        {
            return JsonConvert.SerializeObject(
                new AlertViewModel
                {
                    Title = "ONG reprovada!",
                    Message = "ONG Reprovada! Ainda é possível refazer o cadastro para tentar novamente.",
                    Icon = "success"
                }
            );
        }
    }
}
