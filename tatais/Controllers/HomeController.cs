using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;
using tatais.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace tatais.Controllers;

public class HomeController : Controller
{
    //List<Shifr> Shifr_tatais;
    //List<History_encrypted> History_Encrypteds;
    MobileContext db;
    public HomeController(MobileContext context)
    {
        db = context;
    }
    public string EncodeText(string inputText)
    {
        // Получаем все записи из базы данных
        List<Shifr> shifrs = db.Shifr_tatais.ToList();
        // Проходимся по каждой записи и заменяем символы
        string newtext = "";
        foreach(char i in inputText)
        {
            int k = 0;
            foreach (var shifr in shifrs)
            {
                
                if (i.ToString() == shifr.old_symbol)
                {
                    
                    newtext += shifr.new_symbol;
                    break;
                }
                k += 1;
                if (k == shifrs.Count) { newtext += i.ToString(); }

            }
        }
        
        return newtext;
    }
    public async Task<IActionResult> Index(string inputText)
    {
        return View(await db.History_Encrypteds.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(History_encrypted user)
    {
        db.History_Encrypteds.Add(user);
        user.encrypted_text= EncodeText(user.original_text);
        Console.WriteLine(user.encrypted_text);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
}
