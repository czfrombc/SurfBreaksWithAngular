using Domain.Entities;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence
{

	public class InMemorySurfBreakData : ISurfBreakData
	{
		private List<SurfBreak> surfBreaks;

		public InMemorySurfBreakData()
		{
			surfBreaks = new List<SurfBreak>()
			{
				new SurfBreak { Id = 1, Name = "Uluwatu", Location = "Bali", Break = SurfBreak.BreakType.Reef },
				new SurfBreak { Id = 2, Name = "Laniakea", Location = "Oahu", Break = SurfBreak.BreakType.Reef },
				new SurfBreak { Id = 3, Name = "Ocean Beach", Location = "California", Break = SurfBreak.BreakType.Beach },
				new SurfBreak { Id = 4, Name = "Santa Catalina", Location = "Brazil", Break = SurfBreak.BreakType.Beach }
			};
		}

		public SurfBreak GetSurfBreakById(int id)
		{
			return surfBreaks.SingleOrDefault(sb => sb.Id == id);
		}

		public IEnumerable<SurfBreak> GetAll()
		{
			return surfBreaks;
		}

		public IEnumerable<SurfBreak> GetSurfBreakByName(string surfBreak)
		{
			var filteredSurfBreak = !string.IsNullOrEmpty(surfBreak) ?
				char.ToUpper(surfBreak[0]) + surfBreak.Substring(1) :
				null;

			return from sb in surfBreaks
				   where string.IsNullOrEmpty(surfBreak) || sb.Name.StartsWith(filteredSurfBreak)
				   orderby sb.Name
				   select sb;
		}

		public SurfBreak Update(SurfBreak updatedSurfBreak)
		{
			var surfBreak = surfBreaks.SingleOrDefault(sb => sb.Name == updatedSurfBreak.Name);
			if (surfBreak != null)
			{
				surfBreak.Name = updatedSurfBreak.Name;
				surfBreak.Location = updatedSurfBreak.Location;
				surfBreak.Break = updatedSurfBreak.Break;
			}

			foreach(var sb in surfBreaks) {
				if (sb.Id == surfBreak.Id)
                {
					sb.Name = updatedSurfBreak.Name;
					sb.Location = updatedSurfBreak.Location;
					sb.Break = updatedSurfBreak.Break;
				}
            }
			return surfBreak;
		}

		public SurfBreak Add(SurfBreak newSurfBreak)
		{
			surfBreaks.Add(newSurfBreak);
			newSurfBreak.Id = surfBreaks.Max(sb => sb.Id) + 1;
			return newSurfBreak;
		}

		public SurfBreak Delete(int breakId)
		{
			var surfBreak = surfBreaks.FirstOrDefault(sb => sb.Id == breakId);
			if (surfBreak != null)
			{
				surfBreaks.Remove(surfBreak);
			}
			return surfBreak;
		}

		public int Commit()
		{
			return 0;
		}

		public int GetCountOfSurfBreaks()
		{
			return surfBreaks.Count();
		}
	}
}
