using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTrackerMVC.Models;
using PetCareTrackerMVC.Repositories;
using System.Security.Claims;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PetCareTrackerMVC.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private readonly BaseRepository _repo;
        public PetsController(BaseRepository repo) { _repo = repo; }
        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        public async Task<IActionResult> Index(string searchKeyword = "")
        {
            IEnumerable<PetDto> pets;
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
            }
            else
            {
                pets = await _repo.Query<PetDto>("sp_Pet_Search", new { Keyword = searchKeyword, UserId = GetUserId() });
            }
            ViewBag.SearchKeyword = searchKeyword;
            return View(pets);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PetDto pet)
        {
            await _repo.Execute("sp_Pet_Add", new { pet.PetName, pet.Species, pet.Breed, pet.Gender, pet.BirthDate, pet.Weight, UserId = GetUserId() });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
            var pet = pets.FirstOrDefault(p => p.PetId == id);
            if (pet == null) return NotFound();
            return View(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PetDto pet)
        {
            await _repo.Execute("sp_Pet_Update", new { pet.PetId, pet.PetName, pet.Species, pet.Breed, pet.Gender, pet.BirthDate, pet.Weight });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Execute("sp_Pet_Delete", new { PetId = id });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExportExcel()
        {
            var pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Hastalar");
            sheet.Cells[1,1].Value = "Adı"; sheet.Cells[1,2].Value = "Türü"; sheet.Cells[1,3].Value = "Irkı";
            int r=2; foreach(var p in pets) { sheet.Cells[r,1].Value=p.PetName; sheet.Cells[r,2].Value=p.Species; sheet.Cells[r,3].Value=p.Breed; r++; }
            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Hastalar.xlsx");
        }
        
        public async Task<IActionResult> ExportPdf()
        {
            var pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
            var doc = Document.Create(c => {
                c.Page(p => {
                    p.Size(PageSizes.A4);
                    p.Margin(2, Unit.Centimetre);
                    p.Content().Column(col => {
                        col.Item().Text("Kayıtlı Hastalar").FontSize(20).Bold();
                        foreach(var pt in pets) { col.Item().Text($"- {pt.PetName} ({pt.Species} / {pt.Breed})"); }
                    });
                });
            });
            return File(doc.GeneratePdf(), "application/pdf", "Hastalar.pdf");
        }
    }
}

