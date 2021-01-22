using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaPrograms
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
            return Page();
        }

        [BindProperty]
        public DiplomaProgram DiplomaProgram { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DiplomaPrograms.Add(DiplomaProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
