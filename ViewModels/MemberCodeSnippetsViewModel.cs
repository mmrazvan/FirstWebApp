using FirstMVCApp.Models;

namespace FirstMVCApp.ViewModels
{
	public class MemberCodeSnippetsViewModel
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public string Position { get; set; }
		public List<CodeSnippetsModel> CodeSnippets = new List<CodeSnippetsModel>();
	}
}
