using System;

namespace ORM
{
    public class Bet
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int LotId { get; set; }
        public virtual Lot Lot { get; set; }
    }
}