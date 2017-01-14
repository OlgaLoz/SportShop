using System;
using DAL.Interfaces.Interfaces.Entity;

namespace DAL.Interfaces.Entities
{
    public class DalLot : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public int BetCount { get; set; }
        public byte[] Image { get; set; }
        public string LastBetUser { get; set; }
        public DateTime LastBetTime { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}