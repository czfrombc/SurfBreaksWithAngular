using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using SurfBreaks;

namespace SurfBreaks.Application.Interfaces
{
    public interface ISurfBreakData
	{
		IEnumerable<SurfBreak> GetAll();
		IEnumerable<SurfBreak> GetSurfBreakByName(string name);
		SurfBreak GetSurfBreakById(int id);
		SurfBreak Update(SurfBreak updatedSurfBreak);
		SurfBreak Add(SurfBreak newSurfBreak);
		SurfBreak Delete(int id);
		int GetCountOfSurfBreaks();
		int Commit();
	}
}
 