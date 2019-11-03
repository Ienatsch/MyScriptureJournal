using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any Scriptures.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "1 Nephi",
                        Chapter = 1,
                        LineNumber = "12",
                        Verse = "And it came to pass that as he read, he was filled with the Spirit of the Lord",
                        Note = "Great verse that speaks volumes to me",
                        DateAdded = DateTime.Parse("2019-2-12")
                    },

                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = 32,
                        LineNumber = "2",
                        Verse = @"And it came to pass that after much labor among them, they began to have success among the poor class of people;
                                 for behold, they were cast out of the synagogues because of the coarseness of their apparel",
                        Note = "This verse is a great reminder",
                        DateAdded = DateTime.Parse("2007-6-22")
                    },

                    new Scripture
                    {
                        Book = "Proverbs",
                        Chapter = 18,
                        LineNumber = "13",
                        Verse = "To answer before listening — that is folly and shame.",
                        Note = @"We have two ears and one mouth for a reason. It’s always best to listen first in any situation and speak last, 
                                 after you’ve had time to consider fully what has been said",
                        DateAdded = DateTime.Parse("2014-1-01")
                    },

                    new Scripture
                    {
                        Book = "Psalm",
                        Chapter = 37,
                        LineNumber = "23-24",
                        Verse = "The LORD makes firm the steps of the one who delights in him; though he may stumble, he will not fall, for the LORD upholds him with his hand.",
                        Note = @"Running your business will challenge you in ways you never considered. There will be days when you stumble, 
                                but God will always be there to catch you and lift you back up.",
                        DateAdded = DateTime.Parse("2018-12-31")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
