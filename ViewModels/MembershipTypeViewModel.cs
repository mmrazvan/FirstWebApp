using FirstMVCApp.Models;

namespace FirstMVCApp.ViewModels
{
    public class MembershipTypeViewModel
    {
        public string MembershipType { get; set; }
        public Guid IDMember { get; set; }
        public List<MemberModel> Members = new List<MemberModel>();

    }
}
