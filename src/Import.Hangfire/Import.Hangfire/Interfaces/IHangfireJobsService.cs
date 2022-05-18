using Hangfire;

namespace Import.Hangfire.Interfaces
{
    interface IHangfireJobsService
    {
        [AutomaticRetry(Attempts = 0)]
        void ImportarDados();
    }
}
