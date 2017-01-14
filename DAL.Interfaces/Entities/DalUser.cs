using System.Collections.Generic;
using DAL.Interfaces.Interfaces.Entity;

namespace DAL.Interfaces.Entities
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}