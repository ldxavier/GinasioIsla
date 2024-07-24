using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GinasioIsla.Data;
using GinasioIsla.Models;

namespace GinasioIsla.Pages.Modalidades
{
    public class IndexModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public IndexModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

        public IList<Modalidade> Modalidade { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Modalidade != null)
            {
                Modalidade = await _context.Modalidade.ToListAsync();
            }
        }
    }
}
