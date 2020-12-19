using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //public UsersController(IMediator mediator)
        //{
        //    if (mediator == null)
        //        throw new ArgumentNullException(nameof(mediator));

        //    _mediator = mediator;
        //}
    }
}
