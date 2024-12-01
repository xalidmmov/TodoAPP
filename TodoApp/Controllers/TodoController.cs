using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TodoApp.Contexts;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        public async Task <IActionResult> Index()
        {
            using (TodoDataBaseContext context = new()) {
                
                return View(await context.Todos.ToListAsync());
               
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(Todo data)
        {
            using (TodoDataBaseContext context = new())
            {

                await context.Todos.AddAsync(data);
                await context.SaveChangesAsync();  
                
            }
                return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(!id.HasValue)
            {
                return BadRequest();
            }
            using(TodoDataBaseContext context = new())
            {
               if(await context.Todos.AnyAsync(x => x.Id == id))
                {
                    context.Todos.Remove(new Todo { Id=id.Value });
                    await context.SaveChangesAsync();
                }
            }
            //return Json(new { });
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            using(TodoDataBaseContext context = new())
            {
                var data=await context.Todos.FindAsync(id.Value);
                if(data is null) return NotFound();
                return View(data);
            }
            return View();
        }
    }
}
