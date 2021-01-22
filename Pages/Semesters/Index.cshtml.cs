using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.Semesters
{
    public class IndexModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        public IList<Semester> Semester { get;set; }

        public async Task OnGetAsync()
        {
            Semester = await _context.Semesters
                .Include(s => s.AcademicYear).ToListAsync();
        }
    }
}
