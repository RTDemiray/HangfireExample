using System.Threading.Tasks;
using HangfireExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HangfireExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IFireAndForgetJobsService _fireAndForgetJobsService;
        private readonly IRecurringJobsService _recurringJobsService;
        private readonly IDelayedJobsService _delayedJobsService;
        private readonly IContinuationsJobsService _continuationsJobsService;

        public JobController(IFireAndForgetJobsService fireAndForgetJobsService, IRecurringJobsService recurringJobsService, IDelayedJobsService delayedJobsService, IContinuationsJobsService continuationsJobsService)
        {
            _fireAndForgetJobsService = fireAndForgetJobsService;
            _recurringJobsService = recurringJobsService;
            _delayedJobsService = delayedJobsService;
            _continuationsJobsService = continuationsJobsService;
        }

        [HttpGet("ExecuteFireAndForgetJobs")]
        public async Task<IActionResult> ExecuteFireAndForgetJobs()
        {
            var response = await _fireAndForgetJobsService.Run("FireAndForgetJobs");
            return Ok(response);
        }

        [HttpGet("ExecuteRecurringJobs")]
        public async Task<IActionResult> ExecuteRecurringJobs()
        {
            var response = await _recurringJobsService.Run("RecurringJobs");
            return Ok(response);
        }
        
        [HttpGet("ExecuteDelayedJobs")]
        public async Task<IActionResult> ExecuteDelayedJobs()
        {
            var response = await _delayedJobsService.Run("RecurringJobs");
            return Ok(response);
        }
        
        [HttpGet("ExecuteContinuationsJobs")]
        public async Task<IActionResult> ExecuteContinuationsJobs()
        {
            var response = await _continuationsJobsService.Run("ContinuationsJobs");
            return Ok(response);
        }
    }
}