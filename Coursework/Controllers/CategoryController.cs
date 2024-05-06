using Microsoft.AspNetCore.Mvc;
using Coursework_DataAccess;
using Coursework_Models;
using Microsoft.AspNetCore.Authorization;
using Coursework_Utility;
using Coursework_DataAccess.Repository.IRepository;

namespace Coursework.Controllers
{
    [Authorize(Roles = WebConstants.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;

        public CategoryController(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _catRepo.GetAll();
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) {
                _catRepo.Add(obj);
                _catRepo.Save();
                TempData[WebConstants.Success] = "Категория успешно добавлена!";
                return RedirectToAction("Index");
            }
            TempData[WebConstants.Error] = "Ошибка при создании категории!";
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0) { return NotFound(); }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if(obj == null) { return NotFound(); }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
                _catRepo.Save();
                TempData[WebConstants.Success] = "Категория успешно изменена!";
                return RedirectToAction("Index");
            }
            TempData[WebConstants.Error] = "Ошибка при изменении категории!";
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj == null) { return NotFound(); }
            _catRepo.Remove(obj);
            _catRepo.Save();
            TempData[WebConstants.Success] = "Категория успешно удалена!";
            return RedirectToAction("Index");
        }
    }
}
