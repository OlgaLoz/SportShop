using System;

namespace BLL.Interfaces.Entities
{
    public class BllBet
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LotId { get; set; }
        public string LotName { get; set; }
    }
}