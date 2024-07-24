using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GinasioIsla.Data;
using GinasioIsla.Models;

namespace GinasioIsla.Pages.Inscricoes
{
    public class IndexModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public IndexModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

        public IList<Inscricao> Inscricao { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inscricao != null)
            {
                Inscricao = await _context.Inscricao
                .Include(i => i.Aluno)
                .Include(i => i.Modalidade).ToListAsync();
            }
        }
    }
}
