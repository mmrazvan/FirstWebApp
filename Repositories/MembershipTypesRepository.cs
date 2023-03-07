using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
	public class MembershipTypesRepository
	{
		private readonly ProgrammingClubDataContext _context;
		public MembershipTypesRepository(ProgrammingClubDataContext context)
		{
			_context = context;
		}
		public DbSet<MembershipTypeModel> GetMembershipTypes()
		{
			return _context.MembershipTypes;
		}

		public void Add(MembershipTypeModel model)
		{
			model.IDMembershipType = Guid.NewGuid();
			_context.MembershipTypes.Add(model);
			_context.SaveChanges();
		}

		public MembershipTypeModel GetMembershipTypeById(Guid id)
		{
			MembershipTypeModel membershipType = _context.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == id);
			return membershipType;
		}

		public void Update(MembershipTypeModel model)
		{
			_context.MembershipTypes.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			MembershipTypeModel membershipType = GetMembershipTypeById(id);
			_context.MembershipTypes.Remove(membershipType);
			_context.SaveChanges();
		}

        public MembershipTypeViewModel GetMembershipTypeViewModelById(Guid id)
        {
            MembershipTypeViewModel model = new MembershipTypeViewModel();
            MembershipTypeModel membershipTypeModel = _context.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == id);
            List<Guid> membersGuid = _context.Memberships.Where(x => x.IDMembershipType == membershipTypeModel.IDMembershipType).Select(x => x.IDMember).Distinct().ToList();
            if (membersGuid != null && membershipTypeModel != null)
            {
                model.MembershipType = membershipTypeModel.Name;
                IQueryable<MemberModel> members = _context.Members.Where(member => membersGuid.Contains(member.IDMember));
                foreach (var member in members)
                {
                    model.Members.Add(member);
                }
            }
            return model;
        }
    }
}
