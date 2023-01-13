using dotnet_mvc.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApi.Models;

 namespace dotnet_mvc.productControllers
 {
     public class productController : Controller
     {
        public IActionResult homePage()
        {
            return View();
        }

        // [ViewComponent] //TESTE 
        // public class Footer : ViewComponent
        // {
        //     public async Task<IViewComponentResult> InvokeAsync()
        //     {
        //     return View();
        //     }
        // }
        
        [HttpPost]
        public async Task<IActionResult> homePage(productViewModel product)
        {
            using (var pgsql = new npgsqlCon())
            return RedirectToAction(nameof(registerProductPage));
        }
        public IActionResult registerProductPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> registerProductPage(productViewModel product)
        {
            using (var pgsql = new npgsqlCon())     
            return RedirectToAction(nameof(homePage));
        }
     }
 }