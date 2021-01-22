using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.AdvisingAssignments
{
    public class EditModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public EditModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                .Include(a => a.Instructor).FirstOrDefaultAsync(m => m.Id == id);

            if (AdvisingAssignment == null)
            {
                return NotFound();
            }
           ViewData["DiplomaProgramYearSectionId"] = new SelectList(_context.DiplomaProgramYearSections, "Id", "Title");
           ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AdvisingAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisingAssignmentExists(AdvisingAssignment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdvisingAssignmentExists(int id)
        {
            return _context.AdvisingAssignments.Any(e => e.Id == id);
        }
    }
}
