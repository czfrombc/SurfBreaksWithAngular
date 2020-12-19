using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SurfBreaksDbContext : DbContext, ISurfBreaksDbContext
    {
        public SurfBreaksDbContext(DbContextOptions<SurfBreaksDbContext> options)
            : base(options)
        {
        }

        public DbSet<SurfBreak> SurfBreaks { get; set; }
        
        Task<int> ISurfBreaksDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurfBreak>().HasData(
                new SurfBreak
                {
                    Id = 100,
                    Name = "Puerto Escondido",
                    Location = "Oaxaca",
                    Break = SurfBreak.BreakType.Beach
                },
                new SurfBreak
                {
                    Id = 101,
                    Name = "Santa Teresa",
                    Location = "Costa Rica",
                    Break = SurfBreak.BreakType.Reef
                }
            );
        }
    }
}
