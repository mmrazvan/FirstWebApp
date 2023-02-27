using FirstMVCApp.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
	public class MembershipTypesController : Controller
	{
		private readonly MembershipTypesRepository _repository;
		public MembershipTypesController(MembershipTypesRepository repository) => _repository = repository;

		public IActionResult Index()
		{
			var membershipTypes = _repository.GetMembershipTypes();
			return View("Index", membershipTypes);
		}
	}
}
