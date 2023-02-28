﻿using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
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
	}
}
