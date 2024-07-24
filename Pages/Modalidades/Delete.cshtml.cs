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
    public class DeleteModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public DeleteModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Modalidade == null)
            {
                return NotFound();
            }
            var modalidade = await _context.Modalidade.FindAsync(id);

            if (modalidade != null)
            {
                Modalidade = modalidade;
                _context.Modalidade.Remove(Modalidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
