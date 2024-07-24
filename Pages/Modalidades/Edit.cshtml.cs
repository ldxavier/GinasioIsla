using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GinasioIsla.Data;
using GinasioIsla.Models;

namespace GinasioIsla.Pages.Modalidades
{
    public class EditModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public EditModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Modalidade Modalidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Modalidade == null)
            {
                return NotFound();
            }

            var modalidade =  await _context.Modalidade.FirstOrDefaultAsync(m => m.ModalidadeID == id);
            if (modalidade == null)
            {
                return NotFound();
            }
            Modalidade = modalidade;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Modalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModalidadeExists(Modalidade.ModalidadeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ModalidadeExists(int id)
        {
          return _context.Modalidade.Any(e => e.ModalidadeID == id);
        }
    }
}
