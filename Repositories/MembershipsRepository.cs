using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
	public class MembershipsRepository
	{
		private readonly ProgrammingClubDataContext _context;
		public MembershipsRepository(ProgrammingClubDataContext context)
		{
			_context = context;
		}
		public DbSet<MembershipModel> GetMemberships()
		{
			return _context.Memberships;
		}

		public MembershipModel GetMember(Guid id)
		{
			MembershipModel model = _context.Memberships.FirstOrDefault(x => x.IDMembership == id);
			return model;
		}

		public void AddMember(MembershipModel membershipModel)
		{
			membershipModel.IDMembership = Guid.NewGuid();
			_context.Memberships.Add(membershipModel);
			_context.SaveChanges();
		}
		public void Update(MembershipModel membershipModel
			)
		{
			_context.Memberships.Update(membershipModel);
			_context.SaveChanges();
		}
		public void Delete(Guid id)
		{
			MembershipModel membershipModel = GetMember(id);
			_context.Memberships.Remove(membershipModel);
			_context.SaveChanges();
		}
	}
}
