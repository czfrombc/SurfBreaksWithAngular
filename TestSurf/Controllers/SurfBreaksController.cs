using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Entities;
using Application.SurfBreaks.Queries.GetSurfBreaks;
using Application.SurfBreaks.Queries.GetSurfBreakById;
using Application.SurfBreaks.Commands.UpdateSurfBreaks;
using Application.SurfBreaks.Commands.CreateSurfBreak;
using Application.SurfBreaks.Commands.DeleteSurfBreak;

namespace WebUI.Controllers
{
    public class SurfBreaksController : ApiController
    {
        // GET all surf breaks
        [HttpGet]
        public async Task<IEnumerable<SurfBreak>> Get()
        {
            return (IEnumerable<SurfBreak>)await Mediator.Send(new GetSurfBreaksQuery());
        }

        // GET an existing surf break by Id
        [HttpGet("{id}")]
        public async Task<SurfBreak> GetSurfBreakById([FromRoute] int id)
        {
            GetSurfBreakByIdQuery query = new GetSurfBreakByIdQuery();

            query.Id = id;

            return (SurfBreak)await Mediator.Send(query);
        }

        // POST or create a new surf break
        [HttpPost("{id}")]
        public async Task<ActionResult<int>> Create([FromRoute] int id, [FromBody] SurfBreak surfBreak)
        {
            CreateSurfBreakCommand command = new CreateSurfBreakCommand();

            command.Break = surfBreak.Break;
            command.Location = surfBreak.Location;
            command.Name = surfBreak.Name;

            return await Mediator.Send(command);
        }

        // PUT or update an existing surf break by Id
        [HttpPut("{id}")] 
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] SurfBreak surfBreak)
        {
            UpdateSurfBreakCommand command = new UpdateSurfBreakCommand();

            command.Break = surfBreak.Break;
            command.Id = surfBreak.Id;
            command.Location = surfBreak.Location;
            command.Name = surfBreak.Name;

            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE an existing surf break by Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteSurfBreakCommand { Id = id });

            return NoContent();
        }
    }
}