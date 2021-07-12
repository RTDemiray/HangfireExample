using System.Threading.Tasks;

namespace HangfireExample.Services.Interfaces
{
    public interface IJobsService
    {
        Task<string> Run(string jobType);
        
        public void Apply();
    }
}