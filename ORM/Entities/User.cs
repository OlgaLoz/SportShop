using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }//??

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
            Lots = new HashSet<Lot>();
            Bets = new HashSet<Bet>();
        }

    }
}
