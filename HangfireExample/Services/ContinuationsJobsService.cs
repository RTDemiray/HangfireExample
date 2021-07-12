using System.Threading.Tasks;
using Hangfire;
using HangfireExample.Services.Interfaces;

namespace HangfireExample.Services
{
    public class ContinuationsJobsService : IContinuationsJobsService
    {
        private readonly IDelayedJobsService _delayedJobsService;

        public ContinuationsJobsService(IDelayedJobsService delayedJobsService)
        {
            _delayedJobsService = delayedJobsService;
        }
        
        public async Task<string> Run(string jobType)
        {
            await _delayedJobsService.Run("DelayedJobs");
            var parentJobId = _delayedJobsService.JobId;
            BackgroundJob.ContinueJobWith(parentJobId, () => Apply());
            return await Task.FromResult($"{jobType} çalıştı.");
        }
        
        [JobDisplayName("ContinuationsJobs")]
        public void Apply()
        {
        }
    }
}