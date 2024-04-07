using Microsoft.EntityFrameworkCore;

using UniLearn.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniLearn.Data.Context;

public class UniLearnDbContext : DbContext
{
    public UniLearnDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CardDeck> CardDecks { get; set; }

    public DbSet<Card> Cards { get; set; }
}
