using FirstProjectORM.Data.Repository;
using FirstProjectORM.Data.Repository.IRepository;
using FirstProjectORM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;

namespace FirstProjectORM.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class VehicleController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IWebHostEnvironment _hostEnvironement;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IUnitOfWork unitofwork, IWebHostEnvironment hostEnvironement,ILogger<VehicleController>logger,IMemoryCache memoryCache)
        {
            _unitofwork = unitofwork;
            _hostEnvironement = hostEnvironement;
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    var vehiclelist = _unitofwork.Vehicle.GetAll();
        //    return View(vehiclelist);
        //}

        public IActionResult Index()
        {

            var vehiclelist = _unitofwork.Vehicle.GetAll();
            _logger.LogInformation("Toplam {Count} adet TUR veri tabanından listelendi.", vehiclelist.Count());
            return View(vehiclelist);
        }


        public IActionResult Crup(int? id = 0)
        {
            VehicleVM vehicleVM = new()
            {
                Vehicle = new(),
                VehicleTypeList = _unitofwork.VehicleType.GetAll().Select(x => new SelectListItem
                {
                    Text = x.TypeName,
                    Value = x.Id.ToString()
                })


            };

            if (id == null || id <= 0)
            {
                return View(vehicleVM);
            }

            vehicleVM.Vehicle = _unitofwork.Vehicle.GetFirstOrDefault(x => x.Id == id);
            if (vehicleVM.Vehicle == null)
            {
                return View(vehicleVM);

            }

            return View(vehicleVM);
        }
        [HttpPost]
        public IActionResult Crup(VehicleVM vehicleVM, IFormFile file)
        {
            string wwwRootPath = _hostEnvironement.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\vehiclerss");
                var extension = Path.GetExtension(file.FileName);

                if (vehicleVM.Vehicle.Photo != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath, vehicleVM.Vehicle.Photo);

                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension),
                     FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                vehicleVM.Vehicle.Photo = @"\img\vehiclerss\" + fileName + extension;

            }

            if (vehicleVM.Vehicle.Id <= 0)
            {
                _unitofwork.Vehicle.Add(vehicleVM.Vehicle);
            }
            else
            {
                _unitofwork.Vehicle.Update(vehicleVM.Vehicle);
            }
            _unitofwork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var vehicle = _unitofwork.Vehicle.GetFirstOrDefault(x => x.Id == id);
            _unitofwork.Vehicle.Remove(vehicle);
            _unitofwork.Save();
            return RedirectToAction("Index");
        }
    }
}

