//using BatchService.Common.Trigger.Operators;
using BatchService.Trigger.Operators;

namespace BatchService.Trigger.Operators.Default;

public class DefaultTaskOperator : ITaskOperator
{
    private static readonly RecurringJobOptions DEFAULT_JOB_OPTIONS = new()
    {
        TimeZone = TimeZoneInfo.Local
    };

    public string AddEnqueueJob(Expression<Action> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall);
    }

    public string AddEnqueueJob<T>(Expression<Action<T>> methodCall) where T : new()
    {
        return BackgroundJob.Enqueue(methodCall);
    }

    public string AddDelayJob(Expression<Action> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(methodCall, delay);
    }

    public string AddDelayJob<T>(Expression<Action<T>> methodCall, TimeSpan delay) where T : new()
    {
        return BackgroundJob.Schedule(methodCall, delay);
    }

    public string AddDelayJob(Expression<Action> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(methodCall, enqueueAt);
    }

    public string AddDelayJob<T>(Expression<Action<T>> methodCall, DateTimeOffset enqueueAt) where T : new()
    {
        return BackgroundJob.Schedule(methodCall, enqueueAt);
    }

    public string AddRecurringJob(Expression<Action> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null)
    {
        var jobId = GetUniqueJobId();
        RecurringJob.AddOrUpdate(jobId, queue, methodCall, cronExpression, options ?? DEFAULT_JOB_OPTIONS);
        return jobId;
    }

    public string AddRecurringJob<T>(Expression<Action<T>> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null) where T : new()
    {
        var jobId = GetUniqueJobId();
        RecurringJob.AddOrUpdate(jobId, queue, methodCall, cronExpression, options ?? DEFAULT_JOB_OPTIONS);
        return jobId;
    }

    public string UpdateRecurringJob(string jobId, Expression<Action> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null)
    {
        RecurringJob.AddOrUpdate(jobId, queue, methodCall, cronExpression, options ?? DEFAULT_JOB_OPTIONS);
        return jobId;
    }

    public string UpdateRecurringJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null) where T : new()
    {
        RecurringJob.AddOrUpdate(jobId, queue, methodCall, cronExpression, options ?? DEFAULT_JOB_OPTIONS);
        return jobId;
    }

    public string ContinueJobWith(string parentJobId, Expression<Action> methodCall)
    {
        return BackgroundJob.ContinueJobWith(parentJobId, methodCall);
    }

    public string ContinueJobWith<T>(string parentJobId, Expression<Action<T>> methodCall) where T : new()
    {
        return BackgroundJob.ContinueJobWith(parentJobId, methodCall);
    }

    public void DeleteRecurringJob(string jobId)
    {
        RecurringJob.RemoveIfExists(jobId);
    }

    public bool DeleteBackgroundJob(string jobId)
    {
        return BackgroundJob.Delete(jobId);
    }

    public string GetUniqueJobId()
    {
        return Guid.NewGuid().ToString("N");
    }

    #region 2024年1月17日にRockによって追加された

    public void RunningDaily(
        string jobId,
        int hour24, int minute,
        Expression<Action> methodCall)
    {
        RecurringJob.AddOrUpdate(
            jobId,
            methodCall,
            Cron.Daily(hour24, minute));
    }

    public void RunningWeekly(
        string jobId,
        int hour24, int minute,
        string weeks,
        Expression<Action> methodCall)
    {
        RecurringJob.AddOrUpdate(
            jobId,
            methodCall,
            minute + " " + hour24 + " * * " + weeks);
    }

    #endregion
}
