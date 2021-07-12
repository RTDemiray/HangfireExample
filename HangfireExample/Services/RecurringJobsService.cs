using System.Threading.Tasks;
using Hangfire;
using HangfireExample.Services.Interfaces;

namespace HangfireExample.Services
{
    public class RecurringJobsService : IRecurringJobsService
    {
        public async Task<string> Run(string jobType)
        {
            RecurringJob.AddOrUpdate(() => Apply(),"*/1 * * * * "); //her 1 dakikada çalış.
            return await Task.FromResult($"{jobType} çalıştı.");
        }
        
        [JobDisplayName("RecurringJobs")]
        public void Apply()
        {
        }
    }
}