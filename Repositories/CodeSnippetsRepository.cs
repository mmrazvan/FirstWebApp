using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
	public class CodeSnippetsRepository
	{
		private readonly ProgrammingClubDataContext _context;
		public CodeSnippetsRepository(ProgrammingClubDataContext context)
		{
			_context = context;
		}
		public DbSet<CodeSnippetsModel> GetCodeSnippets() // get all
		{
			return _context.CodeSnippets;
		}

		public CodeSnippetsModel GetCodeSnippetById(Guid id) // get code snippet for a certain ID
		{
			CodeSnippetsModel codeSnippetsModel = _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id);
			return codeSnippetsModel;
		}

		public void Add(CodeSnippetsModel codeSnippetsModel)
		{
			codeSnippetsModel.IdCodeSnippet = Guid.NewGuid();

			_context.Entry(codeSnippetsModel).State = EntityState.Added;
			_context.SaveChanges();
		}

		public void Update(CodeSnippetsModel codeSnippetsModel)
		{
			_context.CodeSnippets.Update(codeSnippetsModel);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			CodeSnippetsModel codeSnippetsModel = GetCodeSnippetById(id);
			_context.CodeSnippets.Remove(codeSnippetsModel);
			_context.SaveChanges();
		}

	}
}
