using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Hi(string name,int age) { 
        //{    JsonResult json=new JsonResult(new
        //{
        //    name=name,
        //    age=age
        //});
        //    return json;



        //ContentResult content = new ContentResult();
        //    content.Content = "<h1>salam</h1>";
        //    content.ContentType = "text/html";

        
            ViewData["name"] = "Ricardo";
            ViewData["surname"] = "Quaresma";
           
            return View();
        }
        public int vay(int id) {
            return id;
        }
    }
}
