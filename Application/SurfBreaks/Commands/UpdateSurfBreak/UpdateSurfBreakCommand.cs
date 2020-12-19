using Domain.Entities;
using MediatR;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domain.Entities.SurfBreak;

namespace Application.SurfBreaks.Commands.UpdateSurfBreaks
{
    public class UpdateSurfBreakCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public BreakType Break { get; set; }
    }


    public class UpdateSurfBreakCommandHandler : IRequestHandler<UpdateSurfBreakCommand>
    {
        private readonly ISurfBreakData _surfBreakData;

        public UpdateSurfBreakCommandHandler(ISurfBreakData surfBreakData)
        {
            _surfBreakData = surfBreakData;
        }

        public async Task<Unit> Handle(UpdateSurfBreakCommand request, CancellationToken cancellationToken)
        {
            SurfBreak surfBreak = new SurfBreak();
            var entity = _surfBreakData.GetSurfBreakById(request.Id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Location = request.Location;
                entity.Break = request.Break;
                surfBreak = _surfBreakData.Update(entity);
            }

            return Unit.Value;
        }
    }
}
