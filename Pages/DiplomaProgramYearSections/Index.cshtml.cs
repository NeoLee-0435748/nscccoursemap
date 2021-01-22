using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaProgramYearSections
{
    public class IndexModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaProgramYearSection> DiplomaProgramYearSection { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaProgramYearSection = await _context.DiplomaProgramYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaProgramYear).ToListAsync();
        }
    }
}
