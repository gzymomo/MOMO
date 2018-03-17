
namespace MOMO.Domain
{
    public class RoleMenu
    {
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public long MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
