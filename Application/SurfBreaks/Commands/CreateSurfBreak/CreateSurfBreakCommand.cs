using Domain.Entities;
using MediatR;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domain.Entities.SurfBreak;

namespace Application.SurfBreaks.Commands.CreateSurfBreak
{
    public partial class CreateSurfBreakCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public BreakType Break { get; set; }
    }


    public class CreateSurfBreakCommandHandler : IRequestHandler<CreateSurfBreakCommand, int>
    {
        private readonly ISurfBreakData _surfBreakData;

        public CreateSurfBreakCommandHandler(ISurfBreakData surfBreakData)
        {
            _surfBreakData = surfBreakData;
        }

        public async Task<int> Handle(CreateSurfBreakCommand request, CancellationToken cancellationToken)
        {
            var entity = new SurfBreak();
            entity.Name = request.Name;
            entity.Location = request.Location;
            entity.Break = request.Break;

            var surfBreak = _surfBreakData.Add(entity);

            // _context.TodoLists.Add(entity);
            // await _context.SaveChangesAsync(cancellationToken);

            return surfBreak.Id;
        }
    }
}
