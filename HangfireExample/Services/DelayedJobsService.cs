using System;
using System.Threading.Tasks;
using Hangfire;
using HangfireExample.Services.Interfaces;

namespace HangfireExample.Services
{
    public class DelayedJobsService : IDelayedJobsService
    {
        public async Task<string> Run(string jobType)
        {
            JobId = BackgroundJob.Schedule(() => Apply(), TimeSpan.FromSeconds(10));
            return await Task.FromResult($"{jobType} çalıştı.");
        }
        
        [JobDisplayName("DelayedJobs")]
        public void Apply()
        {
        }

        public string JobId { get; set; }
    }
}