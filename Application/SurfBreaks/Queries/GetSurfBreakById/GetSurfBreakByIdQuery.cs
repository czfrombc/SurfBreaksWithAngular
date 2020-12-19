using Application.Interfaces;
using Domain.Entities;
using MediatR;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SurfBreaks.Queries.GetSurfBreakById
{
    public class GetSurfBreakByIdQuery : IRequest<SurfBreak>
    {
        public int Id { get; set; }
    }

    public class GetSurfBreaksQueryHandler : IRequestHandler<GetSurfBreakByIdQuery, SurfBreak>
    {
        private readonly ISurfBreaksDbContext _context;
        private readonly ISurfBreakData _surfBreakData;
        private IEnumerable<SurfBreak> surfBreaks;

        public GetSurfBreaksQueryHandler(ISurfBreaksDbContext context, ISurfBreakData surfBreakData)
        {
            _context = context;
            _surfBreakData = surfBreakData;
        }

        public async Task<SurfBreak> Handle(GetSurfBreakByIdQuery request, CancellationToken cancellationToken)
        {
            var surfBreak = _surfBreakData.GetSurfBreakById(request.Id);
            
            return await Task.FromResult(surfBreak);
        }
    }
}
