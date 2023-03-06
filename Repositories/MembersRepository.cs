using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
	public class MembersRepository
	{
		private readonly ProgrammingClubDataContext _context;
		public MembersRepository(ProgrammingClubDataContext context)
		{
			_context = context;
		}
		public DbSet<MemberModel> GetMembers()
		{
			return _context.Members;
		}

		public void Add(MemberModel model)
		{
			model.IDMember = Guid.NewGuid();
			_context.Members.Add(model);
			_context.SaveChanges();
		}

		public MemberModel GetMemberById(Guid id)
		{
			MemberModel member = _context.Members.FirstOrDefault(m => m.IDMember == id);
			return member;
		}

		public void Update(MemberModel model)
		{
			_context.Members.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id) 
		{
			MemberModel model = GetMemberById(id);
			_context.Members.Remove(model);
			_context.SaveChanges();
		}  
		public MemberCodeSnippetsViewModel GetMemberCodeSnippet(Guid memberID)
		{
			MemberCodeSnippetsViewModel memberCodeSnippetsViewModel = new MemberCodeSnippetsViewModel();
			MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember == memberID);
			if (member != null)
			{
				memberCodeSnippetsViewModel.Name = member.Name;
				memberCodeSnippetsViewModel.Position = member.Position;
				memberCodeSnippetsViewModel.Title = member.Title;
				IQueryable<CodeSnippetsModel> memberCodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == memberID);
				foreach(CodeSnippetsModel dbCodeSnippet in memberCodeSnippets)
				{
					memberCodeSnippetsViewModel.CodeSnippets.Add(dbCodeSnippet);
				}
			}
			return memberCodeSnippetsViewModel;
		}
	}
}
