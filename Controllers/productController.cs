using dotnet_mvc.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Validator;
using WebApi.Models;

 namespace dotnet_mvc.productControllers
 {
     public class productController : Controller
     {
        public IActionResult homePage()
        {
            return View();
        }
        
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
     }
 }