using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GinasioIsla.Data;
using GinasioIsla.Models;

namespace GinasioIsla.Pages.Inscricoes
{
    public class CreateModel : PageModel
    {
        private readonly GinasioIsla.Data.GinasioContext _context;

        public CreateModel(GinasioIsla.Data.GinasioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AlunoID"] = new SelectList(_context.Aluno, "ID", "ID");
        ViewData["ModalidadeID"] = new SelectList(_context.Modalidade, "ModalidadeID", "ModalidadeID");
            return Page();
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inscricao.Add(Inscricao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
