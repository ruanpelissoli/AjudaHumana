using AjudaHumana.Core.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjudaHumana.ONG.Domain
{
    public class Goal : BaseEntity
    {
        public Guid RequestId { get; private set; }
        public string ItemName { get; private set; }
        public int CurrentGoal { get; private set; }
        public int FinishedGoal { get; private set; }
        public bool Finished { get; private set; }

        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }

        protected Goal() { }

        public Goal(string itemName, int currentGoal, int finishedGoal, Guid requestId)
        {
            RequestId = requestId;
            ItemName = itemName;
            CurrentGoal = currentGoal;
            FinishedGoal = finishedGoal;
        }

        public void IsFinished()
        {
            if (CurrentGoal >= FinishedGoal)
                Finished = true;
            else
                Finished = false;
        }

        public void UpdateCurrentGoal(int currentGoal)
        {
            CurrentGoal = currentGoal;
            UpdatedAt = DateTime.Now;
            IsFinished();
        }
    }
}
