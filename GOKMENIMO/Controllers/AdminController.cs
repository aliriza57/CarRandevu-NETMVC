
using GOKMENIMO.Models.DB;
using Microsoft.AspNetCore.Mvc;
using GOKMENIMO.Models;
using PET_GIDA.Models;

namespace GOKMENIMO.Controllers
{
    [LoginControlAdminFilter]
    public class AdminController : Controller
    {

        private readonly GOKMENContext _context;

        public AdminController(GOKMENContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // var adminId = HttpContext.Session.GetString("loginId");
            // var adminIdInt = Convert.ToInt32(adminId);
            // var admin = _context.Admins.FirstOrDefault(a => a.Id == adminIdInt);


            ViewBag.RandevuSayisi = _context.Randevus.Count();
            return View();
        }
        public IActionResult Randevular()
        {
            var TumRandevular = _context.Randevus.ToList();
            return View(TumRandevular);
        }
        [HttpPost]
        public IActionResult RandevuSilAjax([FromBody] Randevu randevu)
        {
            if (randevu == null) return Json("0");
            var silinecekRandevu = _context.Randevus.FirstOrDefault(o => o.Id == randevu.Id);
            if (silinecekRandevu == null) return Json("0");
            _context.SaveChanges();
            _context.Randevus.Remove(silinecekRandevu);
            _context.SaveChanges();
            return Json("1");
        }
        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin", "Home");
        }
    }
}