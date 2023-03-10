using FirstMVCApp.DataContext;
using FirstMVCApp.Models;

using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class AnnouncementsRepository
	{
		// clase repository = clase care implementreaza operatiile CRUD pe Baza de date

		private readonly ProgrammingClubDataContext _context;
		public AnnouncementsRepository(ProgrammingClubDataContext context) 
		{
			_context = context;
		}
		public DbSet<AnnouncementModel> GetAnnouncements()
		{
			return _context.Announcements;
		}

		public void Add(AnnouncementModel model)
		{
			model.IdAnnouncement = Guid.NewGuid();

			_context.Announcements.Add(model);
			_context.SaveChanges();
		}

		public AnnouncementModel GetAnnouncementById(Guid id)
		{
			AnnouncementModel announcement = _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == id);
			return announcement;
		}

		public void Update(AnnouncementModel model)
		{
			AnnouncementModel m = GetAnnouncementById(model.IdAnnouncement);
			if (m != null)
			{
				_context.Announcements.Update(model);
				_context.SaveChanges(); 
			}
		}

		public void Delete(Guid id)
		{
			AnnouncementModel announcement = GetAnnouncementById(id);
			if (announcement != null)
			{
				_context.Announcements.Remove(announcement);
				_context.SaveChanges(); 
			}
		}
	}
}
