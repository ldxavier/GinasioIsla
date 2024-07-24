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
    public class DetailsModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public DetailsModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

      public Inscricao Inscricao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricao.FirstOrDefaultAsync(m => m.InscricaoID == id);
            if (inscricao == null)
            {
                return NotFound();
            }
            else 
            {
                Inscricao = inscricao;
            }
            return Page();
        }
    }
}
