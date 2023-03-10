using FirstMVCApp.Models;
using FirstMVCApp.Repositories;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _repository;
        private readonly MembersRepository _membersRepository;

        public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersRepository)
        {
            _repository = repository;
            _membersRepository = membersRepository;
        }
        // GET: CodeSnippetsController
        public ActionResult Index()
        {
            var codeSnippets = _repository.GetCodeSnippets();
            return View("Index", codeSnippets);
        }

        // GET: CodeSnippetsController/Details/5
        public ActionResult Details(Guid id)
        {
            CodeSnippetsModel codeSnippet =  _repository.GetCodeSnippetById(id);
            return View("Details", codeSnippet);
        }

        // GET: CodeSnippetsController/Create
        public ActionResult Create()
        {
            var members = _membersRepository.GetMembers();
            ViewBag.Data = members;
            return View("Create");
        }

        // POST: CodeSnippetsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            CodeSnippetsModel model = new CodeSnippetsModel();
            TryUpdateModelAsync(model);
            _repository.Add(model);

            return RedirectToAction("Index");
        }

        // GET: CodeSnippetsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetsModel codeSnippetModel = _repository.GetCodeSnippetById(id);
            return View("Edit", codeSnippetModel);
        }

        // POST: CodeSnippetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            CodeSnippetsModel codeSnippetsModel = _repository.GetCodeSnippetById(id);
            TryUpdateModelAsync(codeSnippetsModel);
            _repository.Update(codeSnippetsModel);
            return RedirectToAction("Index");
        }

        // GET: CodeSnippetsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            CodeSnippetsModel model = _repository.GetCodeSnippetById(id);

            return View("Delete", model);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);            
            return RedirectToAction("Index");
        }

        
    }
}
