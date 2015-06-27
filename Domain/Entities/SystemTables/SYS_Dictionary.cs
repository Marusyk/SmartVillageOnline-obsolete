using Domain.Abstract;

namespace Domain.Entities.SystemTables
{
    public class SYS_Dictionary : BaseEntity
    {
        public string Name { get { return Name; } }
        public string Description { get { return Description; } }
        public bool IsStatic { get { return IsStatic; } }
    }
}
