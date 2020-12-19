using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SurfBreaks.Queries.GetSurfBreaks
{
    public class GetSurfBreaksQuery : IRequest<IEnumerable<SurfBreak>>
    {
    }

    public class GetSurfBreaksQueryHandler : IRequestHandler<GetSurfBreaksQuery, IEnumerable<SurfBreak>>
    {
        private readonly ISurfBreaksDbContext _context;
        private readonly ISurfBreakData _surfBreakData;
        private IEnumerable<SurfBreak> surfBreaks;

        public GetSurfBreaksQueryHandler(ISurfBreaksDbContext context, ISurfBreakData surfBreakData)
        {
            _context = context;
            _surfBreakData = surfBreakData;

        }

        public async Task<IEnumerable<SurfBreak>> Handle(GetSurfBreaksQuery request, CancellationToken cancellationToken)
        {
            surfBreaks =_surfBreakData.GetAll();

            return await Task.FromResult(surfBreaks);
        }
    }
}
