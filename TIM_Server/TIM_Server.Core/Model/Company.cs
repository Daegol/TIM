using System;
using System.Collections.Generic;

namespace TIM_Server.Core.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        private ISet<Soldier> _soldiers = new HashSet<Soldier>();
        public IEnumerable<Soldier> Soldiers => _soldiers;

        public virtual Commander Commander { get; set; }
        public Guid? CommanderId { get; set; }

        private ISet<Service> _services = new HashSet<Service>();
        public IEnumerable<Service> Services => _services;

        private ISet<Report> _reports = new HashSet<Report>();
        public IEnumerable<Report> Reports => _reports;
    }
}