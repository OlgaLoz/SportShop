using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class BllUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }//?? 
    }
}