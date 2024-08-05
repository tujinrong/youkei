' 
' // *******************************************************************
' // 業務名称　: 互助防疫システム
' // 機能概要　: バッチ管理
' //
' // 作成日　　: 2023.09.05
' // 作成者　　: 
' // 変更履歴　:
' // *******************************************************************
' using Newtonsoft.Json;
' using System.Diagnostics;
' using System.Reflection;
' 
' namespace JBD.GJS.Db
' {
' public class DaJobService
' {
' 
' public enum EnumJobStatus { none=5, Started = 1, Success=2, Failure=3 }
' public static bool IsRuning;
' public static Task MainTask;
' public static void Start()
' {
' IsRuning=true;
' MainTask = Task.Run(() => Run());
' }
' public static void End()
' {
' IsRuning = false;
' }
' 
' 
' private static void Run()
' {
' bool useSemaphoere = false;
' int maxThreads = 4;
' Semaphore semaphore= new Semaphore(maxThreads, maxThreads);
' 
' for (; ; )
' {
' try
' {
' using (var db = new DaDbContext())
' {
' 
' var servernm = Environment.MachineName; // 実行サーバー
' var filter = $"{nameof(tt_afjobDto.syoridttmf)} is null and {nameof(tt_afjobDto.syoridttmt)} is null and {nameof(tt_afjobDto.servernm)} = @{nameof(tt_afjobDto.servernm)} AND {nameof(tt_afjobDto.yoteidttm)}<='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'";
' var joblist = db.tt_afjob.SELECT.WHERE.ByFilter(filter, servernm).GetDtoList();
' 
' if (!Sleep(0)) return;
' // 記録情報ログ
' var startDate = DaUtil.Now;                       
' //スレッド数を制限する
' if (useSemaphoere)
' {
' for (int i = 0; i < joblist.Count; i++)
' {
' var dto = joblist[i];
' Trace.TraceInformation("-----------------開始時間--------------" + startDate + " ジョブシーケンス:" + dto.jobseq);
' Trace.TraceInformation("-----------------処理の計数--------------" + i+1);
' ThreadPool.QueueUserWorkItem(state =>
' {
' semaphore.WaitOne(); 
' try
' {
' UpdateDto(db, dto);
' RunJob(dto, startDate);
' }
' finally
' {
' semaphore.Release(); 
' }
' });
' }
' }
' else
' {
' for (int i = 0; i < joblist.Count; i++)
' {
' var dto = joblist[i];
' Trace.TraceInformation("-----------------開始時間--------------" + startDate + " ジョブシーケンス:" + dto.jobseq);
' Trace.TraceInformation("-----------------処理の計数--------------" + i+1);
' UpdateDto(db, dto);
' Task.Run(() => RunJob(dto, startDate));
' if (!Sleep(6)) return;
' }
' }
' }
' 
' }
' catch (Exception ex)
' {
' return;
' }
' if (!Sleep(30)) return;
' }
' }
' 
' private static void UpdateDto(DaDbContext db, tt_afjobDto dto)
' {
' db.tt_afjob.UPDATE.WHERE.ByKey(dto.jobseq).Execute(dto);
' }
' private static bool Sleep(int second)
' {
' for (int i = 0; i < second; i++)
' {
' if (!IsRuning) return false;
' Thread.Sleep(1000);
' }
' return true;
' }
' public static void RunJob(tt_afjobDto dto, DateTime startDate)
' {
' using (var db = new DaDbContext())　　　　　　
' {
' var stopwatch = new Stopwatch();
' stopwatch.Start();
' dto.syoridttmf = startDate;
' db.tt_afjob.UPDATE.WHERE.ByKey(dto.jobseq).Execute(dto);
' // サーバーからのダウンロード パスを見つける
' string absolutePath = typeof(DaJobService).Assembly.Location;
' int index = absolutePath.IndexOf("WebService");
' if (index != -1 && dto.assemby.Length !=0)
' {
' // バックエンドの前でパスをインターセプトする　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
' string result = absolutePath.Substring(0, index);
' dto.assemby = result + dto.assemby;
' }
' DaResponseBase res = RunMethod(dto.assemby, dto.nmspace, dto.kinoid, dto.method, dto.pram);
' 
' var fieldInfo = res.GetType().GetProperty("data");
' 
' var byteDate = (byte[])fieldInfo.GetValue(res)  new byte[1];
' 
' dto.syoridttmt = DaUtil.Now;
' Trace.TraceInformation("-----------------終了時間--------------" + DaUtil.Now + " ジョブシーケンス:" + dto.jobseq);
' db.tt_afjob.UPDATE.WHERE.ByKey(dto.jobseq).Execute(dto);
' stopwatch.Stop();
' 
' //EUC帳票検索履歴テーブル
' var rekiDto = new tt_eurirekiDto();
' rekiDto.reportid = dto.jobseq;
' rekiDto.outputkbn = Enum出力方式.PDF;
' rekiDto.jyotaikbn = Enum履歴出力状態区分.処理完了;
' rekiDto.num = 1;
' rekiDto.tm = (int)stopwatch.ElapsedMilliseconds;
' rekiDto.filedata = byteDate;
' rekiDto.reguserid = dto.reguserid;
' rekiDto.regdttm = DaUtil.Now;
' db.tt_eurireki.INSERT.Execute(rekiDto);
' 
' }
' }
' 
' public static int Schedule(DaDbContext db, object service, string methodName, object request, DateTime time)
' {
' Type stype = service.GetType();
' var sasm = stype.Assembly;
' var requestString= JsonConvert.SerializeObject(request);
' Schedule(db, sasm.Location, stype.Namespace!, stype.Name, methodName, requestString, time);
' return 0;
' }
' 
' public static int Schedule(DaDbContext db, string assembly, string nameSpace, string serviceName, string methodName, string requestString, DateTime time)
' {
' var dto = new tt_afjobDto()
' {
' yoteidttm = time,
' assemby = assembly,
' nmspace = nameSpace,
' kinoid = serviceName,
' method = methodName,
' pram = requestString
' };
' db.tt_afjob.INSERT.Execute(dto);
' return 0;    
' }
' 
' public static DaResponseBase RunMethod(string assembly, string nameSpace, string serviceName, string methodName, string requestString)
' {
' Assembly asm = Assembly.LoadFrom(assembly);
' var service = $"{nameSpace}.{serviceName}";
' var obj = asm.CreateInstance(service);
' if (obj == null) return new DaResponseBase() { returncode = EnumServiceResult.Exception, message = "Method Error" };
' 
' MethodInfo method = obj.GetType().GetMethod(methodName)!;
' 
' //パラメータが存在する場合
' if (string.IsNullOrEmpty(requestString))
' {
' return (DaResponseBase)method.Invoke(obj, null)!;
' }
' else
' {
' // パラメータを取得
' var reqType = method.GetParameters()[0].ParameterType;
' var para = JsonConvert.DeserializeObject(requestString, reqType);
' return (DaResponseBase)(method.Invoke(obj, new object[] { para }))!;
' }
' }
' }
' }
' 
