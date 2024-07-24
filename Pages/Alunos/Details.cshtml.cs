using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GinasioIsla.Data;
using GinasioIsla.Models;

namespace GinasioIsla.Pages.Alunos
{
    public class DetailsModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public DetailsModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

      public Aluno Aluno { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .Include(i => i.Inscricoes)
                .ThenInclude(m => m.Modalidade)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (aluno == null)
            {
                return NotFound();
            }
            else 
            {
                Aluno = aluno;
            }
            return Page();
        }
    }
}
