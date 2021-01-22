using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaPrograms
{
    public class DetailsModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        public DiplomaProgram DiplomaProgram { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgram = await _context.DiplomaPrograms.FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaProgram == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
