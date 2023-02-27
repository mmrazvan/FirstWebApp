using FirstMVCApp.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
	public class MembersController : Controller
	{
		private readonly MembersRepository _repository;

		public MembersController(MembersRepository repository) 
		{
			_repository = repository;
		}	

		public IActionResult Index()
		{
			var members = _repository.GetMembers();
			return View("Index", members);
		}
	}
}
