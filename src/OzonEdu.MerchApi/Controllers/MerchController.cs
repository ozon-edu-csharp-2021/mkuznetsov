using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.HttpModels.Request;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.Queries;

namespace OzonEdu.MerchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator) => _mediator = mediator;

        [HttpGet("[action]/{employeeId:long}")]
        public async Task<ActionResult<IEnumerable<Merch>>> History(long employeeId, CancellationToken cancellationToken)
        {
            var query = new GetMerchByEmployeeIdQuery
            {
                EmployeeId = employeeId
            };
            
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
 
        [HttpPost("[action]")]
        public async Task<ActionResult<MerchStatus>>Order(MerchOrderPost merchOrder, CancellationToken cancellationToken)
        {
            var query = new OrderMerchCommand
            {
                EmployeeId = new EmployeeId(merchOrder.EmployeeId),
                MerchType = MerchType.FromValue<MerchType>((int)merchOrder.MerchType),
            };

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

         // [HttpGet("[action]/{employeeId:long}")]
         // public async Task<ActionResult<Employee>> Employee(long employeeId)
         // {
         //     var employee = await _mediator.Send(new GetEmployeeRequest {EmployeeId = employeeId});
         //
         //     return Ok(employee);
         // }
    }
}