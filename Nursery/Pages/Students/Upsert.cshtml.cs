using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nursery.Model;

namespace Nursery.Pages.Students
{
    public class UpsertModel : PageModel
    {
        private readonly Context _db;

        public UpsertModel(Context db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { set; get; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Student = new Student();
            if (id == null)
            {
                // Return empty page to create new student 
                return Page();
            }

            //for update page
            Student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Student.Id==0)
                {
                    _db.Students.Add(Student);
                }
                else
                {
                    _db.Students.Update(Student);
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}