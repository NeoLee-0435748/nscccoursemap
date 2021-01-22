using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.CourseOfferings
{
    public class IndexModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        public IList<CourseOffering> CourseOffering { get;set; }

        public async Task OnGetAsync()
        {
            CourseOffering = await _context.CourseOfferings
                .Include(c => c.Course)
                .Include(c => c.DiplomaProgramYearSection)
                .Include(c => c.Instructor)
                .Include(c => c.Semester).ToListAsync();
        }
    }
}
