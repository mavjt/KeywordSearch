using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Infrastructure.Data
{
    public class HistoryContext: DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options)
            : base(options)
        {            
        }
        public DbSet<SearchHistory> SearchHistories{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchHistory>().ToTable("SearchHistory");
            
            
        }
    }
}
