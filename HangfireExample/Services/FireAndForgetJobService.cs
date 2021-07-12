using System.Threading.Tasks;
using Hangfire;
using HangfireExample.Services.Interfaces;

namespace HangfireExample.Services
{
    public class FireAndForgetJobsService : IFireAndForgetJobsService
    {
        public async Task<string> Run(string jobType)
        {
            BackgroundJob.Enqueue(() => Apply());
            return await Task.FromResult($"{jobType} çalıştı.");
        }

        [JobDisplayName("FireAndForgetJobs")]
        public void Apply()
        {
        }
    }
}