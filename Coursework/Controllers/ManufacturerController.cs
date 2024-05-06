using Microsoft.AspNetCore.Mvc;
using Coursework_Models;
using Microsoft.AspNetCore.Authorization;
using Coursework_Utility;
using Coursework_DataAccess;
using Coursework_DataAccess.Repository.IRepository;

namespace Coursework.Controllers
{
    [Authorize(Roles = WebConstants.AdminRole)]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerRepository _manufRepo;

        public ManufacturerController(IManufacturerRepository manufRepo)
        {
            _manufRepo = manufRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Manufacturer> objList = _manufRepo.GetAll();
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
        public IActionResult Create(Manufacturer obj)
        {
            if (ModelState.IsValid) {
                _manufRepo.Add(obj);
                _manufRepo.Save();
                TempData[WebConstants.Success] = "Производитель успешно создан!";
                return RedirectToAction("Index"); 
            }
            TempData[WebConstants.Error] = "Ошибка при создании производителя!";
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0) { return NotFound(); }
            var obj = _manufRepo.Find(id.GetValueOrDefault());
            if(obj == null) { return NotFound(); }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer obj)
        {
            if (ModelState.IsValid)
            {
                _manufRepo.Update(obj);
                _manufRepo.Save();
                TempData[WebConstants.Success] = "Производитель успешно изменен!";
                return RedirectToAction("Index");
            }
            TempData[WebConstants.Error] = "Ошибка при изменении производителя!";
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var obj = _manufRepo.Find(id.GetValueOrDefault());
            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _manufRepo.Find(id.GetValueOrDefault());
            if (obj == null) { return NotFound(); }
            _manufRepo.Remove(obj);
            _manufRepo.Save();
            TempData[WebConstants.Success] = "Производитель успешно удален!";
            return RedirectToAction("Index");
        }
    }
}
