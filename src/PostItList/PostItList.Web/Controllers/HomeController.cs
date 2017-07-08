using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostItList.Web.Services;
using System.IO;
using PostItList.Models;

namespace PostItList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoService _toDoService;

        public HomeController(IToDoService service)
        {
            _toDoService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            var items = await _toDoService.GetAll();
            return View(items);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //Going to need error handling
        [HttpPost]
        public async Task<string> AddToDo()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var title = reader.ReadToEnd();
                var item = new ToDoItem { Title = title };
                //catch the bool later
                await _toDoService.Add(item);
                return "Success";
            }
        }
    }
}
