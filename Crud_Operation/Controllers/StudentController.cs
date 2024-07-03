using Crud_Operation.Data;
using Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList; 

namespace Crud_Operation.Controllers
{
    public class StudentController : Controller

    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


       

        [HttpPost]
       
        public async Task<IActionResult> Add(Student Viewmodel)
        {
            var student = new Student
            {
                Name = Viewmodel.Name,
                Email = Viewmodel.Email,
                Phone = Viewmodel.Phone,
                Subscribed = Viewmodel.Subscribed,
            };

            Console.WriteLine(student);

            await dbContext.students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List","Student");
        }
        [HttpGet]
        public async Task<IActionResult> List(int? page)
        {
            int pageSize = 6; 
            int pageNumber = page ?? 1; 

            var students = await dbContext.students.ToPagedListAsync(pageNumber, pageSize);

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           var student = await dbContext.students.FindAsync(id);

            return View(student);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student Viewmodel)
        {
            var student = await dbContext.students.FindAsync(Viewmodel.Id);

            if (student is not null)
            {
                student.Name = Viewmodel.Name;
                student.Email = Viewmodel.Email;
                student.Phone = Viewmodel.Phone;
                student.Subscribed = Viewmodel.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await dbContext.students.FindAsync(id);
            if (student != null)
            {
                dbContext.students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
