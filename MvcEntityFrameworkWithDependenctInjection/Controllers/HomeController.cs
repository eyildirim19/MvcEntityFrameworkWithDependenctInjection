using Microsoft.AspNetCore.Mvc;
using MvcEntityFrameworkWithDependenctInjection.Models;
using System.Diagnostics;

namespace MvcEntityFrameworkWithDependenctInjection.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext dbContext;
		public HomeController(AppDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public IActionResult Index()
        {
            var result = dbContext.Categories.ToList();
            return View(result);
        }

        public IActionResult Top10Category()
        {
            var result = dbContext.Categories.OrderBy(c => c.Id).Take(10).ToList();

            return View(result);
        }
    }
}

// DIP => bağımlıklaları tersine çevirme
// DI  => bağımlıkların enjecte edilmesi
// IoC => instancelerin yönetilmesi.. instancein tek bir yerden verilmesi.. (ömrü değişebilir)
// IoC (Inversion of Control) => IoC uygulama içerisindeki instancleri (sürekli instance almayı reddeder) yönetilmesini sağlayan yazılım prensibidir. Instance tek bir yer oluşturulur bu oluşurulan yapıya container denir. Instance bekleyen yerlere instance bu container üzerinden enjecte edilir (dependency injection)
// IoC yapısı asp.net core'da built-in gelmiştir.. yani projece instanceleri tek biryerden yönetmek ve enject etmek için ayrı bir kütüphaneye gerek yoktur... DI yapısını kullanan türlere asp.net core'da servis denmektedir.. bu servisler asp.net core framework servisleri kullanabilir veya kendi servisleirmizi yazabiliriz.. Bu servisleri yönettiğimiz yer .net6 dan önce startup.cs .net6 ile program.cs dosyasıdır.. devamına orada..
