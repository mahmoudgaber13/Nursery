using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nursery.Model;

namespace Nursery.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly Context _db;

        public EditModel(Context db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { set; get; }
        public async Task OnGet(int id)
        {
            Student = await _db.Students.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                Student old = await _db.Students.FindAsync(Student.Id);
                old.Name = Student.Name;
                old.Address = Student.Address;
                old.Phone = Student.Phone;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}