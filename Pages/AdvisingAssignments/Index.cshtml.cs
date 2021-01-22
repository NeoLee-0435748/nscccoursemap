using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.AdvisingAssignments
{
    public class IndexModel : PageModel
    {
        private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

        public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get;set; }

        public async Task OnGetAsync()
        {
            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                .Include(a => a.Instructor).ToListAsync();
        }
    }
}
