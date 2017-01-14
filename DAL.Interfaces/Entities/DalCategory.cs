using DAL.Interfaces.Interfaces.Entity;

namespace DAL.Interfaces.Entities
{
    public class DalCategory : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int LotCount { get; set; }
    }
}