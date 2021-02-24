using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaProgramYears
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
        ViewData["DiplomaProgramId"] = new SelectList(_context.DiplomaPrograms, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public DiplomaProgramYear DiplomaProgramYear { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DiplomaProgramYears.Add(DiplomaProgramYear);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
