using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
	public class CodeSnippetsModel
	{
		[Key]
		public Guid? IdCodeSnippet { get; set; }
		public string Title { get; set; }
		public string ContentCode { get; set; }
		public Guid IDMember { get; set; }
		public int Revision { get; set; }
		public DateTime DateTimeAdded { get; set; }
		public bool IsPublished { get; set; }

	}
}
