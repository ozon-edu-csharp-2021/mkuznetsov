﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.HttpModels;
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
                EmployeeId = merchOrder.EmployeeId,
                MerchType = merchOrder.MerchType,
                MerchOptions = merchOrder.MerchOptions
            };

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}