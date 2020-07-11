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
    public class IndexModel : PageModel
    {
        private readonly Context _db;

        public IndexModel(Context db)
        {
            _db = db;
        }

        public IEnumerable<Student> students { get; set; }
        public async Task OnGet()
        {
            students = await _db.Students.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Student student = await _db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}