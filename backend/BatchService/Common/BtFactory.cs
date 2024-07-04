// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチサービスインスタンス管理
//            
// 作成日　　: 2023.01.12
// 作成者　　: 屠
// 変更履歴　: 
// *******************************************************************
using System.Reflection;

namespace BCC.Affect.BatchService
{
    public class BtFactory
    {
        //private Dictionary<string, Expression<Action<string, string>>> _tasks = new Dictionary<string, Expression<Action<string, string>>>();

        public static IBtService GetService(string name)
        {
            //switch (name)
            //{
            //    case nameof(ABSH00101G): return new ABSH00101G.Service();
            //    case nameof(Task1): return new Task1();
            //    case nameof(Task2): return new Task2();

            //    default: throw new NotImplementedException();
            //}
            var serviceFullName = $"BCC.Affect.BatchService.{name}.Service";
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(serviceFullName);

            if (type != null && typeof(IBtService).IsAssignableFrom(type))
            {
                return (IBtService)Activator.CreateInstance(type)!;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        //public Expression<Action<string, string>> GetTaskExpression(string taskIndex)
        //{
        //    Tasks tasks = new Tasks(taskIndex);
        //    _tasks = tasks.Tsks;

        //    if (_tasks.TryGetValue(taskIndex, out var taskExpression))
        //    {
        //        return taskExpression;
        //    }

        //    throw new ArgumentException("Invalid strategy key");
        //}
    }
}