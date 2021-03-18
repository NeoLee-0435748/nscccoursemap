using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.CourseOfferings
{
    public class CreateModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public CreateModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
        ViewData["DiplomaProgramYearSectionId"] = new SelectList(_context.DiplomaProgramYearSections, "Id", "Title");
        ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName");
        ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CourseOffering CourseOffering { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CourseOfferings.Add(CourseOffering);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
