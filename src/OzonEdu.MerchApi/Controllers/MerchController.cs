using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.HttpModels;
using OzonEdu.MerchApi.Infrastructure.Queries;
using MerchStatus = OzonEdu.MerchApi.Infrastructure.HttpModels.MerchStatus;

namespace OzonEdu.MerchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator) => _mediator = mediator;

        [HttpGet("[action]/{employeeId:long}")]
        public async Task<ActionResult<IEnumerable<MerchInfo>>> History(long employeeId, CancellationToken cancellationToken)
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
                EmployeeId = merchOrder.EmployeeId,
                MerchType = merchOrder.MerchType,
                MerchOptions = merchOrder.MerchOptions
            };

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<MerchInfo>>> StatusSku(MerchStatusSkuPost merchStatusSkuPost, CancellationToken cancellationToken)
        {
            var query = new GetMerchByStatusSkuQuery()
            {
                MerchStatus = merchStatusSkuPost.MerchStatus,
                Skus = merchStatusSkuPost.Skus
            };
            
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}