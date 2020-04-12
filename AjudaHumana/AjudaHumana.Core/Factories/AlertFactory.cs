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
                    Type = "alert",
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
                    Type = "alert",
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
                    Type = "alert",
                    Title = "ONG reprovada!",
                    Message = "ONG Reprovada! Ainda é possível refazer o cadastro para tentar novamente.",
                    Icon = "success"
                }
            );
        }

        public static string ONGUpdated()
        {
            return JsonConvert.SerializeObject(
                new AlertViewModel
                {
                    Type = "toast",
                    Title = "Dados da ONG atualizados com sucesso!",
                    Message = "Dados da ONG atualizados com sucesso!",
                    Icon = "success"
                }
            );
        }

        public static string NewRequestCreated()
        {
            return JsonConvert.SerializeObject(
                new AlertViewModel
                {
                    Type = "alert",
                    Title = "Pedido criado com sucesso!",
                    Message = "Agora você pode atualizar seus pedidos a medida que doações forem chegando e manter suas metas atualizadas.",
                    Icon = "success"
                }
            );
        }

        public static string RequestEdited()
        {
            return JsonConvert.SerializeObject(
                new AlertViewModel
                {
                    Type = "toast",
                    Title = "Pedido atualizado com sucesso!",
                    Message = "Pedido atualizado com sucesso!",
                    Icon = "success"
                }
            );
        }
    }
}
