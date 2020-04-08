using AjudaHumana.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjudaHumana.ONG.Domain
{
    public class Request : BaseEntity
    {
        public Guid ONGId { get; private set; }
        public string Description { get; private set; }
        public bool Finished { get; private set; }

        [ForeignKey("ONGId")]
        public virtual NonGovernamentalOrganization ONG { get; private set; }
        public virtual ICollection<Goal> Goals { get; private set; }

        protected Request () { }

        public Request(string description, Guid ongId)
        {
            ONGId = ongId;
            Description = description;
            
            Goals = new List<Goal>();
        }

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }
        
        public void RemoveGoal(Goal goal)
        {
            Goals.Remove(goal);
        }
    }
}
