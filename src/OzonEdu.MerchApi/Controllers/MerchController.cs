using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.HttpModels.Enums;
using OzonEdu.MerchApi.HttpModels.Request;
using OzonEdu.MerchApi.HttpModels.Response;

namespace OzonEdu.MerchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchController : ControllerBase
    {
        [HttpGet("[action]/{employeeId:long}")]
        public async Task<ActionResult<List<MerchHistoryResult>>> History(long employeeId, CancellationToken token)
        {
            if (employeeId != 1 && employeeId != 2) throw new ArgumentException("employeeId is wrong!");
            
            var merches = new List<MerchHistoryResult>()
            {
                new()
                {
                    EmployeeId = 1,
                    IssueDate = DateTime.Now,
                    MerchType = MerchType.WelcomePack,
                    Status = OrderStatus.Waiting
                },
                new()
                {
                    EmployeeId = 1,
                    IssueDate = DateTime.Now,
                    MerchType = MerchType.ConferenceListenerPack,
                    Status = OrderStatus.Ready
                },
                new()
                {
                    EmployeeId = 2,
                    IssueDate = DateTime.Now,
                    MerchType = MerchType.ConferenceListenerPack,
                    Status = OrderStatus.Ready
                }
            };

            return Ok(merches.Where(m => m.EmployeeId == employeeId).ToList());
        }
 
        [HttpPost("[action]")]
         public async Task<ActionResult<MerchOrderResult>> Order(MerchOrderPost merchOrder, CancellationToken token)
         {
            var employeeId = merchOrder.EmployeeId;
            if (employeeId != 1 && employeeId != 2) throw new ArgumentException("employeeId is wrong!");
                
            var result = new MerchOrderResult()
            {
                Status = OrderStatus.Ready
            };

            return Ok(result);
        }
    }
}