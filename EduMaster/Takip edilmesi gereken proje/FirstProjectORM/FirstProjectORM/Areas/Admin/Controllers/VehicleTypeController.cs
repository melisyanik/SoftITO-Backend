using FirstProjectORM.Data.Repository.IRepository;
using FirstProjectORM.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectORM.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class VehicleTypeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public VehicleTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            IEnumerable<VehicleType> vehicleTypes = _unitOfWork.VehicleType.GetAll();


            return View(vehicleTypes);
        }


        public IActionResult Create()
        {


            return View();
        }




        [HttpPost]
        public IActionResult Create(VehicleType vehicleType)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.VehicleType.Add(vehicleType);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return View(vehicleType);


        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {


                return NotFound();
            }
            var types = _unitOfWork.VehicleType.GetFirstOrDefault(x => x.Id == id);

            return View(types);
        }

        [HttpPost]
        public IActionResult Edit(VehicleType vehicleType)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.VehicleType.Update(vehicleType);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return View(vehicleType);


        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {


                return NotFound();
            }
            var types = _unitOfWork.VehicleType.GetFirstOrDefault(x => x.Id == id);

            _unitOfWork.VehicleType.Remove(types);
            _unitOfWork.Save();
            return RedirectToAction("Index");



        }

    }
}