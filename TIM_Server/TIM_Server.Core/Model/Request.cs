using System;

namespace TIM_Server.Core.Model
{
    public class Request
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public byte[] Document { get; set; }
        public virtual Soldier Soldier { get; set; }
        public Guid? SoldierId { get; set; }
    }
}