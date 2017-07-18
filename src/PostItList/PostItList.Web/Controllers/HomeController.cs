using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostItList.Web.Services;
using System.IO;
using PostItList.Models;
using Newtonsoft.Json;

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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> List()
        {
            var items = await _toDoService.GetAll();
            return View(items);

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

        //[HttpPut]
        //public async Task<string> Edit()
        //{
        //    using (var reader = new StreamReader(Request.Body))
        //    {
        //        var json = reader.ReadToEnd();
        //        var item = JsonConvert.DeserializeObject<IEnumerable<ToDoItem>>(json);


        //    }
        //}


    }
}
