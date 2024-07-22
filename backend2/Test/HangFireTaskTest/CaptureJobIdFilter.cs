using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using System.Collections.Concurrent;

namespace HangFireTaskTest
{
    public class CaptureJobIdFilter : JobFilterAttribute, IApplyStateFilter
    {
        public static ConcurrentDictionary<string, string> JobIds = new ConcurrentDictionary<string, string>();

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            var jobId = context.BackgroundJob.Id;

            var args = context.BackgroundJob.Job.Args;
            if (args != null && args.Count > 0 && args[0] is string args1)
            {
                JobIds.TryAdd(args1, jobId);
            }
        }

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
        }
    }
}
