using FirstMVCApp.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
	public class MembershipsController : Controller
	{
		private readonly MembershipsRepository _repository;

		public MembershipsController(MembershipsRepository repository)
		{
			_repository = repository;
		}
		public IActionResult Index()
		{
			var memberships  = _repository.GetMemberships();
			return View();
		}
	}
}
