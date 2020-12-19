using MediatR;
using SurfBreaks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SurfBreaks.Commands.DeleteSurfBreak
{
    public class DeleteSurfBreakCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSurfBreakCommandHandler : IRequestHandler<DeleteSurfBreakCommand>
    {
        private readonly ISurfBreakData _surfBreakData;

        public DeleteSurfBreakCommandHandler(ISurfBreakData surfBreakData)
        {
            _surfBreakData = surfBreakData;
        }

        public async Task<Unit> Handle(DeleteSurfBreakCommand request, CancellationToken cancellationToken)
        {
            _surfBreakData.Delete(request.Id);

            return Unit.Value;
        }
    }
}
