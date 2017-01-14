using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Lot
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public byte[] Image { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Lot()
        {
            Bets = new HashSet<Bet>();
        }
    }
}