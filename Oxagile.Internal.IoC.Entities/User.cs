namespace Oxagile.Internal.IoC.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}