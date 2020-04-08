using AjudaHumana.Core.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjudaHumana.ONG.Domain
{
    public class Goal : BaseEntity
    {
        public Guid RequestId { get; private set; }
        public string ItemName { get; private set; }
        public int CurrentGoal { get; set; }
        public int? FinishedGoal { get; set; }
        public bool Finished { get; set; }

        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }

        protected Goal() { }

        public Goal(string itemName, int currentGoal, int finishedGoal, Request request)
        {
            RequestId = request.Id;
            ItemName = itemName;
            CurrentGoal = currentGoal;
            FinishedGoal = finishedGoal;

            Request = request;
        }
    }
}
