using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nursery.Model;

namespace Nursery.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Context _db;
        public CreateModel(Context db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student {set; get;}
        public void OnGet()
        {

        }
        
        public async Task<IActionResult> OnPost(Student student)
        {
            if(ModelState.IsValid)
            {
                await _db.Students.AddAsync(student);
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