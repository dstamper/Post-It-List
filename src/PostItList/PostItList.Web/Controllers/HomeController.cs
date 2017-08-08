using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostItList.Web.Services;
using System.IO;
using PostItList.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

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
        public async Task<IActionResult> AddToDo()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var json = reader.ReadToEnd();
                var item = JsonConvert.DeserializeObject<ToDoItem>(json);

                //client handling
                if(item.Title == "")
                {
                    return BadRequest(); 
                }

                //if a server error occured, the returned GUID will be the default value
                //using this to decide returned status code
                var serviceResponse = await _toDoService.Add(item);

                if(serviceResponse == default(Guid))
                {
                    return StatusCode(503); //Service Unavailable
                }
                else
                {
                    var output = new JsonResult(serviceResponse);
                    output.StatusCode = 201;
                    return output; //Created
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit()
        {
            using (var reader = new StreamReader(Request.Body))
            {

                var json = reader.ReadToEnd();
                var item = JsonConvert.DeserializeObject<ToDoItem>(json);

                //client handling
                if(item.Title == "")
                {
                    return BadRequest();  //400 error bad request
                }

                var serviceResponse = await _toDoService.Edit(item);
                if (serviceResponse)
                {
                    return StatusCode(200); //OK
                }
                else
                {
                    return StatusCode(500); //Internal Server Error
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var json = reader.ReadToEnd();
                var item = JsonConvert.DeserializeObject<Guid>(json);

                if(item == null || item == default(Guid))
                {
                    return BadRequest(); //400 error bad request
                }

                var serviceResponse = await _toDoService.Delete(item);

                if (serviceResponse)
                {
                    return StatusCode(200); //OK
                }
                else
                {
                    return StatusCode(500); //Internal Server Error
                }

            }
        }


    }
}
