using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stanciu_Oana_Lab2.Models;

namespace Stanciu_Oana_Lab2.Data
{
    public class Stanciu_Oana_Lab2Context : DbContext
    {
        public Stanciu_Oana_Lab2Context (DbContextOptions<Stanciu_Oana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Stanciu_Oana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Stanciu_Oana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Stanciu_Oana_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Stanciu_Oana_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
