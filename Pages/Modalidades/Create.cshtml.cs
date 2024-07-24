﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GinasioIsla.Data;
using GinasioIsla.Models;

namespace GinasioIsla.Pages.Modalidades
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
            return Page();
        }

        [BindProperty]
        public Modalidade Modalidade { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Modalidade.Add(Modalidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
