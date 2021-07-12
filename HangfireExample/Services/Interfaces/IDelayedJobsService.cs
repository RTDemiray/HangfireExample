namespace HangfireExample.Services.Interfaces
{
    public interface IDelayedJobsService : IJobsService
    {
        public string JobId { get; }   
    }
}