using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nursery.Model;

namespace Nursery.Controllers
{
    [Route("api/Students")]
    public class StudentController : Controller
    {
        private readonly Context _db;
        public StudentController(Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _db.Students.ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) 
            {
                return Json(new { success = false , message = "Error while deleting" });
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted Successfully" });

        }
    }
}
