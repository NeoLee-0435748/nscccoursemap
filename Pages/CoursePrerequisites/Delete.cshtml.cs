using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.CoursePrerequisites
{
    public class DeleteModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public DeleteModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoursePrerequisite CoursePrerequisite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoursePrerequisite = await _context.CoursePrerequisites
                .Include(c => c.Course)
                .Include(c => c.Prerequisite).FirstOrDefaultAsync(m => m.Id == id);

            if (CoursePrerequisite == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoursePrerequisite = await _context.CoursePrerequisites.FindAsync(id);

            if (CoursePrerequisite != null)
            {
                _context.CoursePrerequisites.Remove(CoursePrerequisite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
