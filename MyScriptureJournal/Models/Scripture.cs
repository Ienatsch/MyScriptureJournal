using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        [Display(Name = "Line Number")]
        public string LineNumber { get; set; }
        public string Verse { get; set; }
        public string Note { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
}
