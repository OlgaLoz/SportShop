using DAL.Interfaces.Interfaces.Entity;

namespace DAL.Interfaces.Entities
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}