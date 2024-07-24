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
    public class DetailsModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public DetailsModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

      public Modalidade Modalidade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Modalidade == null)
            {
                return NotFound();
            }

            var modalidade = await _context.Modalidade.FirstOrDefaultAsync(m => m.ModalidadeID == id);
            if (modalidade == null)
            {
                return NotFound();
            }
            else 
            {
                Modalidade = modalidade;
            }
            return Page();
        }
    }
}
