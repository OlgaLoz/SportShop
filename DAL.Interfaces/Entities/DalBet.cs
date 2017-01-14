using System;
using DAL.Interfaces.Interfaces.Entity;

namespace DAL.Interfaces.Entities
{
    public class DalBet : IEntity
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LotId { get; set; }
        public string LotName { get; set; }
    }
}