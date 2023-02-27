using FirstMVCApp.Repositories;

using FirstWebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
	//todo same for members and membershiptypes (add silver gold platinum ca valori, nu altceva)
	public class AnnouncementsController : Controller
	{
		private readonly AnnouncementsRepository _repository;
		public AnnouncementsController(AnnouncementsRepository repository)
		{
			_repository = repository;
		}
		public IActionResult Index()
		{
			var announcemments = _repository.GetAnnouncements();
			return View("Index", announcemments);
		}

		public IActionResult Create()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection) 
		{
			AnnouncementModel announcement = new AnnouncementModel();
			TryUpdateModelAsync(announcement); // se mapeaza datele din formular pe model
			_repository.Add(announcement);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id) 
		{
			AnnouncementModel announcement = _repository.GetAnnouncementById(id);
			return View("Edit", announcement);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			AnnouncementModel announcement = _repository.GetAnnouncementById(id);
			TryUpdateModelAsync(announcement);
			_repository.Update(announcement);

			return RedirectToAction("Index");
		}
	}
}
