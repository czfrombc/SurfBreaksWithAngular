using Domain.Entities;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence
{
    public class SqlSurfBreakData : ISurfBreakData
    {
        private readonly SurfBreaksDbContext db;

        public SqlSurfBreakData(SurfBreaksDbContext db)
        {
            this.db = db;
        }

        public SurfBreak Add(SurfBreak newSurfBreak)
        {
            db.Add(newSurfBreak);
            return newSurfBreak;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public SurfBreak Delete(int id)
        {
            var surfBreak = GetSurfBreakById(id);
            if (surfBreak != null)
            {
                db.SurfBreaks.Remove(surfBreak);
            }
            return surfBreak;
        }

        public int GetCountOfSurfBreaks()
        {
            return db.SurfBreaks.Count();
        }

        public SurfBreak GetSurfBreakById(int id)
        {
            return db.SurfBreaks.Find(id);
        }

        public IEnumerable<SurfBreak> GetSurfBreakByName(string name)
        {
            var query = from sb in db.SurfBreaks
                        where sb.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby sb.Name
                        select sb;
            return query;
        }

        public SurfBreak Update(SurfBreak updatedSurfBreak)
        {
            var entity = db.SurfBreaks.Attach(updatedSurfBreak);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedSurfBreak;
        }

        IEnumerable<SurfBreak> ISurfBreakData.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
