using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GOKMENIMO.Models;
using GOKMENIMO.Models.DB;
using System.Text;

namespace GOKMENIMO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GOKMENContext _context;

    public HomeController(ILogger<HomeController> logger, GOKMENContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(Randevu model)
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AdminLogin()
    {
        ViewBag.RandevuSayisi = _context.Randevus.Count();
        return View();
    }
    [HttpPost]
    public IActionResult AdminLogin(LoginModel login)
    {
        if (login == null) return RedirectToAction("AdminLogin");
        var admin = _context.Admins.FirstOrDefault(a => a.KullaniciAdi == login.kullaniciAdi && a.Sifre == login.sifre);
        if (admin != null)
        {
            ViewBag.AdminMessage = "Girilen Bilgiler Doğru";
            HttpContext.Session.SetString("adminloginId", admin.Id.ToString());
            return RedirectToAction("Index", "Admin");
        }
        else
        {
            ViewBag.AdminMessage = "Kullanıcı adı ve şifrenizi kontrol edin";
        }
        return View();
    }
    [HttpPost]
    public IActionResult RandevuEkle([FromBody] Randevu randevu)
    {
        if (ModelState.IsValid)
        {
            var body = new StringBuilder();
            body.AppendLine("Name: " + randevu.Name);
            body.AppendLine("Car Type: " + randevu.CarType);
            body.AppendLine("Work Type: " + randevu.WorkType);
            body.AppendLine("Tel: " + randevu.Tell);
            Mail.MailSender(body.ToString());

            ViewBag.Success = true;
        }

        if (randevu == null) return Json("0");
        _context.Randevus.Add(randevu);
        _context.SaveChanges();
        return Json("1");
    }
    public IActionResult Cikis()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("AdminLogin", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
