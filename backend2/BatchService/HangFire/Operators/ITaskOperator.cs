using System.Linq.Expressions;
using Hangfire;

namespace BatchService.Trigger.Operators;

public interface ITaskOperator
{
    /// <summary>
    /// ただ一度実行される即時実行タスクを追加する
    /// </summary>
    string AddEnqueueJob(Expression<Action> methodCall);

    /// <summary>
    /// ただ一度実行される即時実行タスクを追加する
    /// </summary>
    string AddEnqueueJob<T>(Expression<Action<T>> methodCall) where T : new();

    /// <summary>
    /// 一度だけ実行される遅延実行タスクを追加する
    /// </summary>
    string AddDelayJob(Expression<Action> methodCall, TimeSpan delay);

    /// <summary>
    /// 一度だけ実行される遅延実行タスクを追加する
    /// </summary>
    string AddDelayJob<T>(Expression<Action<T>> methodCall, TimeSpan delay) where T : new();

    /// <summary>
    /// 一度だけ実行される遅延実行タスクを追加する
    /// </summary>
    string AddDelayJob(Expression<Action> methodCall, DateTimeOffset enqueueAt);

    /// <summary>
    /// 一度だけ実行される遅延実行タスクを追加する
    /// </summary>
    string AddDelayJob<T>(Expression<Action<T>> methodCall, DateTimeOffset enqueueAt) where T : new();

    /// <summary>
    /// 複数回実行される周期的なタスクを追加する
    /// </summary>
    string AddRecurringJob(Expression<Action> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null);

    /// <summary>
    /// 複数回実行される周期的なタスクを追加する
    /// </summary>
    string AddRecurringJob<T>(Expression<Action<T>> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null) where T : new();

    /// <summary>
    /// 周期的なタスクを更新する
    /// </summary>
    string UpdateRecurringJob(string jobId, Expression<Action> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null);

    /// <summary>
    /// 周期的なタスクを更新する
    /// </summary>
    string UpdateRecurringJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression, string queue = "default", RecurringJobOptions? options = null) where T : new();

    /// <summary>
    /// あるタスクが完了した後に実行されるタスクを追加する
    /// </summary>
    string ContinueJobWith(string parentJobId, Expression<Action> methodCall);

    /// <summary>
    /// あるタスクが完了した後に実行されるタスクを追加する
    /// </summary>
    string ContinueJobWith<T>(string parentJobId, Expression<Action<T>> methodCall) where T : new();

    /// <summary>
    /// 指定された周期的なタスクを削除する
    /// </summary>
    void DeleteRecurringJob(string jobId);

    /// <summary>
    /// 指定したバックグラウンドタスクの削除（非定期的）
    /// </summary>
    bool DeleteBackgroundJob(string jobId);

    /// <summary>
    /// 一意のジョブIDを取得する
    /// </summary>
    string GetUniqueJobId();

    void RunningWeekly(
        string jobId,
        int hour24, int minute,
        string weeks,
        Expression<Action> methodCall);

    void RunningDaily(
        string jobId,
        int hour24, int minute,
        Expression<Action> methodCall);
}