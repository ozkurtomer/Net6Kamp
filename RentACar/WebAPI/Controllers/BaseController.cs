using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator? Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? mediator;
    }
}
