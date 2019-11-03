using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        public SelectList Note { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NoteKeyword { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            var searchRadioButton = Request.Query["searchByValue"];
            if (searchRadioButton == "book" && SearchString != null)
            {
                SearchByBook();
                return;
            }
            else if (searchRadioButton == "noteKeyword" && SearchString != null)
            {
                SearchByNoteKeyword();
                return;
            }

            BookSort = sortOrder == "book_asc" ? "book_desc" : "book_asc";
            DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            var scriptures = from s in _context.Scripture
                             select s;

            switch (sortOrder)
            {
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "date_asc":
                    scriptures = scriptures.OrderBy(s => s.DateAdded);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.DateAdded);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }
            Scripture = await scriptures.AsNoTracking().ToListAsync();
        }

        public async void SearchByBook()
        {
            var books = from b in _context.Scripture
                        select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Book.Contains(SearchString));
            }

            Scripture = await books.ToListAsync();
        }

        public async void SearchByNoteKeyword()
        {
            var notes = from n in _context.Scripture
                        select n;
            if (!string.IsNullOrEmpty(SearchString))
            {
                notes = notes.Where(s => s.Note.Contains(SearchString));
            }

            Scripture = await notes.ToListAsync();
        }
    }
}
