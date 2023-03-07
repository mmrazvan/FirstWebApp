using FirstMVCApp.Models;
using FirstMVCApp.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController : Controller
	{
		private readonly MembershipsRepository _repository;
		private readonly MembershipTypesRepository _membershipTypesRepository;
		private readonly MembersRepository _membersRepository;

		public MembershipsController(MembershipsRepository repository, MembershipTypesRepository membershipTypesRepository, MembersRepository membersRepository)
		{
			_repository = repository;
			_membershipTypesRepository = membershipTypesRepository;
			_membersRepository = membersRepository;
		}
		public IActionResult Index()
		{
			var memberships  = _repository.GetMemberships();
			return View("Index", memberships);
		}

		public IActionResult Create()
		{
			var membershipTypes = _membershipTypesRepository.GetMembershipTypes();
			var members = _membersRepository.GetMembers();
			ViewBag.Memberships = membershipTypes;
			ViewBag.Members = members;
			return View("Create");
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(IFormCollection collection)
		{
			MembershipModel model = new MembershipModel();
			TryUpdateModelAsync(model);
			_repository.AddMembership(model);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id) 
		{
			MembershipModel membershipModel = _repository.GetMembershipById(id);
            var membershipTypes = _membershipTypesRepository.GetMembershipTypes();
            var members = _membersRepository.GetMembers();
            ViewBag.Memberships = membershipTypes;
            ViewBag.Members = members;
            return View("Edit", membershipModel);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			MembershipModel membershipModel = _repository.GetMembershipById(id);
			TryUpdateModelAsync(membershipModel);
			_repository.Update(membershipModel);
			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			MembershipModel membershipModel = _repository.GetMembershipById(id);
			return View("Delete", membershipModel);
		}

        [HttpPost]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

		public IActionResult Details(Guid id)
		{
			MembershipModel membershipModel = _repository.GetMembershipById(id);
			return View("Details", membershipModel);
		}		
    }
}
