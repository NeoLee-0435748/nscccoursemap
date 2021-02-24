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

namespace NsccCourseMap_Neo.Pages.AcademicYears
{
    public class EditModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public EditModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AcademicYear AcademicYear { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcademicYear = await _context.AcademicYears.FirstOrDefaultAsync(m => m.Id == id);

            if (AcademicYear == null)
            {
                return NotFound();
            }
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

            _context.Attach(AcademicYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicYearExists(AcademicYear.Id))
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

        private bool AcademicYearExists(int id)
        {
            return _context.AcademicYears.Any(e => e.Id == id);
        }
    }
}
