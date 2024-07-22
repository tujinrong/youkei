//using BatchService.Common.Trigger.Operators;
//using BatchService.Common.Trigger.Operators.Default;
using BatchService.Trigger.Operators;
using BatchService.Trigger.Operators.Default;

namespace BCC.Affect.Service;

public abstract class CmAbstractBatchOperateService : CmServiceBase
{
    protected readonly ITaskOperator _taskOperator;
    protected CmAbstractBatchOperateService(DefaultTaskOperator taskOperator)
    {
        _taskOperator = taskOperator;
    }
}