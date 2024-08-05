' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログ処理
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports System.Text.Json.Serialization
Imports Oracle.ManagedDataAccess.Client

Namespace JBD.GJS.Db
    Public Class DaDbLogService
        Private Const MAX_CHARS As Integer = 120


#Region "メインログ、通信ログ"
''' <summary>
''' メインログファイルの作成
''' </summary>
        Public Shared Function WriteMainLog(r As DaRequestBase) As Long
            'Dim displayName = GetDisplayName()

            Using db = New DaDbContext(r)

''' Cannot convert InvocationExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitInvocationExpression(InvocationExpressionSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''                 AIplus.AIF.DBLib.AiDbUtil.OpenConnection(db.Session.Connection!)
''' 
                If db.Session.UserID Is Nothing Then
                    db.Session.UserID = r.USER_ID
                End If
                Dim dto = New tt_aflogDto() With {
                   .syoridttmf = DaUtil.Now,
    .syoridttmt = DaUtil.Now,
    .milisec = 0,
    .reguserid = If(r.USER_ID, String.Empty),
    .statuscd = "0",
    .regdttm = DaUtil.Now
}
                dto.reguserid = If(r.USER_ID, String.Empty)
                dto.sessionseq = CLng(DateTime.Now.ToString("yyyyMMddHHmmssfff"))
                'db.tt_aflog.INSERT.Execute(dto)
                DaDbLogService.InsertDto(db.Session, dto)
                Return dto.sessionseq
            End Using
        End Function

        ''' <summary>
        ''' メインログファイルの作成
        ''' </summary>
        '        Public Shared Function WriteMainLog(r As DaRequestBase) As Long
        '            'var displayName = GetDisplayName();

        '            Using db = New DaDbContext(r)
        '                'AiDbUtil.OpenConnection(db.Session.Connection!);

        '                'if (db.Session.UserID == null)
        '                '{
        '                '    db.Session.UserID = r.userid;
        '                '}
        '                Dim dto = New tt_aflogDto() With {
        '    .syoridttmf = DaUtil.Now,
        '    .syoridttmt = DaUtil.Now,
        '    .milisec = 0,
        '    .reguserid = If(r.userid, String.Empty),
        '    .statuscd = "0",
        '    .regdttm = DaUtil.Now
        '}
        '                dto.reguserid = If(r.userid, String.Empty)

        '                'db.tt_aflog.INSERT.Execute(dto);

        '                Return dto.sessionseq
        '            End Using
        '        End Function

        ''' <summary>
        ''' メインログファイルの作成
        ''' </summary>
        '        Public Shared Function WriteMainLog(db As DaDbContext, kinoid As String, service As String, method As String, methodnm As String) As Long
        '            Dim dto = New tt_aflogDto() With {
        '    .syoridttmf = DaUtil.Now,
        '    .syoridttmt = DaUtil.Now,
        '    .milisec = 0,
        '    .statuscd = "0",
        '    .kinoid = kinoid,
        '    .service = service,
        '    .method = method,
        '    .methodnm = methodnm,

        '    '  reguserid = db.Session.UserID!.ToString()  "",
        '    .regdttm = DaUtil.Now
        '}
        '            'dto.reguserid = r.userid  string.Empty;
        '            'db.tt_aflog.INSERT.Execute(dto);
        '            'セッションシーケンスをセット
        '            'db.Session.SessionData[DaConst.SessionID] = dto.sessionseq;
        '            Return dto.sessionseq
        '        End Function
        ''' <summary>
        ''' 処理ログに書き込み
        ''' </summary>
        Public Shared Function WriteMainLog(db As DaDbContext, dto As tt_aflogDto) As Long
            ' db.tt_aflog.INSERT.Execute(dto);
            Return dto.sessionseq
        End Function

        ''' <summary>
        ''' 処理ログの更新
        ''' </summary>
        Public Shared Sub UpdateMainLog(db As DaDbContext, dto As tt_aflogDto)
            ' db.tt_aflog.UPDATE.Execute(dto);
        End Sub

        Public Shared Sub UpdateMainLog(db As DaDbContext, result As EnumServiceResult)
            Select Case result
                Case EnumServiceResult.OK, EnumServiceResult.Hidden
                    UpdateMainLog(db, EnumLogStatus.正常終了)

                Case EnumServiceResult.ServiceAlert
                    UpdateMainLog(db, EnumLogStatus.要確認)

                Case EnumServiceResult.Exception
                    UpdateMainLog(db, EnumLogStatus.処理停止)
                Case Else
                    UpdateMainLog(db, EnumLogStatus.異常終了)
            End Select
        End Sub

        ''' <summary>
        ''' ログ結果を更新
        ''' </summary>
        ''' <paramname="db"></param>
        ''' <paramname="status"></param>
        Public Shared Sub UpdateMainLog(db As DaDbContext, status As EnumLogStatus)
            '
            'long sessionSeq = (long)db.Session.SessionData[DaConst.SessionID];

            'データを取得
            'var dto = db.tt_aflog.SELECT.WHERE.ByKey(sessionSeq).GetDto();
            ' Dim serviceType As Type = GetType(JBD.GJS.Service.GJ0000)
            '' 获取所有的方法
            'Dim methods As MethodInfo() = serviceType.GetMethods(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)

            '' 遍历每个方法
            'For Each method As MethodInfo In methods
            
            '    ' 获取 DisplayName 属性
            'Dim displayNameAttribute As DisplayNameAttribute = CType(Attribute.GetCustomAttribute(method, GetType(DisplayNameAttribute)), DisplayNameAttribute)
            'If displayNameAttribute IsNot Nothing Then
            '' 输出 DisplayName 属性值
            '    Console.WriteLine($"方法: {method.Name}, DisplayName: {displayNameAttribute.DisplayName}")
            '   End If
            ' Next
'''処理時間を計算
'DateTime time = DaUtil.Now;
'dto.syoridttmt = time;
'DateTime startTime = dto.syoridttmf;
'dto.milisec = Convert.ToInt32(time.Subtract(startTime).TotalMilliseconds);
'dto.statuscd = ((int)status).ToString();

'var dic = db.Session.SessionData;
'dto.kinoid = dic.ContainsKey(nameof(DaRequestBase.Service))  (string)dic[nameof(DaRequestBase.Service)] : string.Empty;
'dto.service = dic.ContainsKey(nameof(DaRequestBase.ServiceDesc))  (string)dic[nameof(DaRequestBase.ServiceDesc)] : string.Empty;
'dto.method = dic.ContainsKey(nameof(DaRequestBase.Method))  (string)dic[nameof(DaRequestBase.Method)] : string.Empty;
'dto.methodnm = dic.ContainsKey(nameof(DaRequestBase.MethodDesc))  (string)dic[nameof(DaRequestBase.MethodDesc)] : string.Empty;

'db.tt_aflog.UPDATE.Execute(dto);
                        Dim sessionSeq = CLng(db.Session.SessionData(DaConst.SessionID))

            'データを取得
            Dim dto = New tt_aflogDto

            '処理時間を計算
            Dim time As Date = DaUtil.Now
            dto.syoridttmt = time
            Dim startTime As Date = dto.syoridttmf
'dto.milisec = Convert.ToInt32(time.Subtract(startTime).TotalMilliseconds)
            dto.statuscd = CInt(status).ToString()
            dto.sessionseq = sessionSeq

            Dim dic = db.Session.SessionData
            dto.kinoid = If(dic.ContainsKey(NameOf(DaRequestBase.Service)), CStr(dic(NameOf(DaRequestBase.Service))), String.Empty)
            dto.service = If(dic.ContainsKey(NameOf(DaRequestBase.ServiceDesc)), CStr(dic(NameOf(DaRequestBase.ServiceDesc))), String.Empty)
            dto.method = If(dic.ContainsKey(NameOf(DaRequestBase.Method)), CStr(dic(NameOf(DaRequestBase.Method))), String.Empty)
            dto.methodnm = If(dic.ContainsKey(NameOf(DaRequestBase.MethodDesc)), CStr(dic(NameOf(DaRequestBase.MethodDesc))), String.Empty)
            dto.reguserid = db.Session.UserID

            Dim _conn = db.Session.Connection
            If _conn.State = Data.ConnectionState.Closed Then
                _conn.Open()
            End If
            Dim updateSql As String = "UPDATE tt_aflog set syoridttmt = :syoridttmt , statuscd = :statuscd , kinoid = :kinoid , service = :service, method = :method, methodnm = :methodnm, reguserid = :reguserid where sessionseq = :sessionseq "
            Dim updateParams As New List(Of OracleParameter) From {
                New OracleParameter("syoridttmt", dto.syoridttmt ),
                New OracleParameter("statuscd", dto.statuscd),
                New OracleParameter("kinoid", dto.kinoid),
                New OracleParameter("service", dto.service),
                New OracleParameter("method", dto.method ),
                New OracleParameter("methodnm", dto.methodnm),
                New OracleParameter("reguserid", dto.reguserid),
                New OracleParameter("sessionseq", dto.sessionseq)
            }
            Using cmd As New OracleCommand(updateSql, _conn)
                cmd.Parameters.AddRange(updateParams.ToArray())
                Try
                    Dim result = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Throw
                End Try
            End Using

            Dim updateSql1 As String = " update 	tt_aflog set MILISEC =  EXTRACT(SECOND FROM (to_TIMESTAMP(to_char(syoridttmt,'YYYY/MM/DD HH24:MI:SS.FF3'),'YYYY/MM/DD HH24:MI:SS.FF3')-to_TIMESTAMP(to_char(syoridttmf,'YYYY/MM/DD HH24:MI:SS.FF3'),'YYYY/MM/DD HH24:MI:SS.FF3'))) * 1000  where sessionseq = :sessionseq"
            Dim updateParams1 As New List(Of OracleParameter) From {
                New OracleParameter("sessionseq", dto.sessionseq)
            }
            Using cmd As New OracleCommand(updateSql1, _conn)
                cmd.Parameters.AddRange(updateParams1.ToArray())
                Try
                    Dim result = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Throw
                End Try
            End Using

            'db.tt_aflog.UPDATE.Execute(dto)
        End Sub

        ''' <summary>
        ''' 通信ログ
        ''' </summary>
        'Public Shared Function WriteTusinLog(db As DaDbContext, request As DaRequestBase, response As DaResponseBase, msg As String) As Long
        '    Try
        '        Dim dto As tt_aftusinlogDto = New tt_aftusinlogDto()
        '        dto.sessionseq = request.sessionid
        '        dto.request = JsonConvert.SerializeObject(request)
        '        dto.response = JsonConvert.SerializeObject(response)
        '        dto.syoridttmf = DaUtil.Now
        '        dto.syoridttmt = DaUtil.Now                    'TODO：仮の通信ログの終了時間
        '        dto.msg = msg
        '        dto.ipadrs = request.ip
        '        dto.browser = request.browser
        '        dto.os = request.os
        '        ' dto.reguserid = (string)db.Session.UserID!;
        '        dto.regdttm = DaUtil.Now
        '        ' db.tt_aftusinlog.INSERT.Execute(dto);
        '        Return dto.tusinlogseq
        '    Catch
        '    End Try
        '    Return 0L
        'End Function

        ''' <summary>
        ''' 通信ログ
        ''' </summary>
        Public Shared Sub UpdateTusinLog(db As DaDbContext, logSeq As Long)
            Try
                Dim dto As tt_aftusinlogDto = New tt_aftusinlogDto()
                dto.sessionseq = logSeq
                'db.tt_aftusinlog.UPDATE.SetUpdateItems(nameof(dto.syoridttmt)).Execute(dto);
                dto.syoridttmt = DaUtil.Now
            Catch
            End Try
        End Sub


        ''' <summary>
        ''' 通信ログ
        ''' </summary>
        'Public Shared Sub WriteTusinLog(db As DaDbContext, msg As String, request As String, response As String, ipadrs As String, os As String, browser As String)
        '    Try
        '        Dim dto As tt_aftusinlogDto = New tt_aftusinlogDto()
        '        dto.syoridttmf = DaUtil.Now
        '        ' dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
        '        dto.request = request
        '        dto.response = response
        '        dto.ipadrs = ipadrs
        '        dto.browser = browser
        '        dto.os = os

        '        ' dto.reguserid = (string)db.Session.UserID!;
        '        '  db.tt_aftusinlog.INSERT.Execute(dto);
        '        dto.regdttm = DaUtil.Now
        '    Catch
        '    End Try
        'End Sub

        ''' <summary>
        ''' 通信ログ
        ''' </summary>
        Public Shared Sub WriteTusinLog(db As DaDbContext, dto As tt_aftusinlogDto)
            ' db.tt_aftusinlog.INSERT.Execute(dto);
        End Sub

        ''' <summary>
        ''' 通信ログ
        ''' </summary>
        Public Shared Function WriteTusinLog(db As DaDbContext, request As DaRequestBase, response As DaResponseBase, msg As String) As Long
            Try
                Dim dto As tt_aftusinlogDto = New tt_aftusinlogDto()
                dto.sessionseq = request.sessionid
                dto.request = System.Text.Json.JsonSerializer.Serialize(request)
                dto.response = System.Text.Json.JsonSerializer.Serialize(response)
                dto.syoridttmf = DaUtil.Now
                dto.syoridttmt = DaUtil.Now                
                dto.msg = msg
                dto.ipadrs = request.ip
                dto.browser = request.browser
                dto.os = request.os
                dto.reguserid = db.Session.UserID
                dto.regdttm = DaUtil.Now
                'db.tt_aftusinlog.INSERT.Execute(dto)
                DaDbLogService.InsertDto(db.Session, dto)
                Return dto.tusinlogseq
            Catch
            End Try
            Return 0L
        End Function
#End Region

#Region "バッチログ"
        ''' <summary>
        ''' バッチログ
        ''' </summary>
        'Public Shared Sub WriteBatchLog(db As DaDbContext, msg As String)
        '    Try
        '        Dim dto As tt_afbatchlogDto = New tt_afbatchlogDto()
        '        ' dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
        '        dto.syoridttmf = DaUtil.Now
        '        dto.msg = msg
        '        ' dto.reguserid = (string)db.Session.UserID!;
        '        ' db.tt_afbatchlog.INSERT.Execute(dto);
        '        dto.regdttm = DaUtil.Now
        '    Catch
        '    End Try
        'End Sub

        ''' <summary>
        ''' バッチログ
        ''' </summary>
        'public static void WriteBatchLog(DaDbContext db, string msg, string param)
        '{
        '    tt_afbatchlogDto dto = new()
        '    {
        '        sessionseq = (long)db.Session.SessionData[DaConst.SessionID],
        '        syoridttmf = DaUtil.Now,
        '        msg = msg,
        '        pram = param,
        '    };
        '    db.tt_afbatchlog.INSERT.Execute(dto);
        '}

        ''' <summary>
        ''' バッチログ
        ''' </summary>
        'public static void WriteBatchLog(DaDbContext db, tt_afbatchlogDto dto)
        '{
        '    db.tt_afbatchlog.INSERT.Execute(dto);
        '}

        ''' <summary>
        ''' バッチログの追加（複数場合使用）
        ''' </summary>
        '        Public Shared Sub AddBatchLog(dtoList As List(Of tt_afbatchlogDto), msg As String, Optional param As String = "")
        '                        ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        ''''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
        ''''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        ''''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        ''''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
        '''' 
        '''' Input:
        ''''             JBD.GJS.Db.tt_afbatchlogDto dto = new()
        ''''             {
        ''''                 syoridttmf = JBD.GJS.Db.DaUtil.Now,
        ''''                 msg = msg,
        ''''                 pram = @param,
        ''''                 regdttm = JBD.GJS.Db.DaUtil.Now
        ''''             };
        '''' 
        '''' 
        '            dtoList.Add(dto)
        '        End Sub

        ''' <summary>
        ''' バッチログ（複数場合使用）
        ''' </summary>
        'public static void WriteBatchLog(DaDbContext db, List<tt_afbatchlogDto> dtoList)
        '{
        '    var sessionSeq = (long)db.Session.SessionData[DaConst.SessionID];
        '    foreach (var dto in dtoList)
        '    {
        '        dto.sessionseq = sessionSeq;
        '    }
        '    db.tt_afbatchlog.INSERT.SetBulkInsert().Execute(dtoList);
        '}

#End Region

#Region "外部連携"
        ''' <summary>
        ''' 外部連携
        ''' </summary>
        Public Shared Sub WriteGaibuLog(db As DaDbContext, dto As tt_afgaibulogDto)
            ' db.tt_afgaibulog.INSERT.Execute(dto);
        End Sub

        ''' <summary>
        ''' 外部連携（通信の場合）
        ''' </summary>
        Public Shared Sub WriteGaibuLog(db As DaDbContext, msg As String, ipadrs As String, kbn As EnumGaibuKbn, kbn2 As EnumGaibuDataType)
            'tt_afgaibulogDto dto = new tt_afgaibulogDto()
            '{
            '    sessionseq = (long)db.Session.SessionData[DaConst.SessionID],
            '    syoridttmf = DaUtil.Now,
            '    msg = msg,
            '    ipadrs = ipadrs,
            '    kbn = ((int)kbn).ToString(),
            '    kbn2 = ((int)kbn2).ToString()
            '};
            'db.tt_afgaibulog.INSERT.Execute(dto);
        End Sub

        ''' <summary>
        ''' 外部連携（ファイルの場合）
        ''' </summary>
        Public Shared Sub WriteGaibuLog(db As DaDbContext, apidata As String, filenm As String, filetype As EnumFileTypeKbn, filesize As Integer, filedata As Byte())
            'tt_afgaibulogDto dto = new tt_afgaibulogDto()
            '{
            '    sessionseq = (long)db.Session.SessionData[DaConst.SessionID],
            '    syoridttmf = DaUtil.Now,
            '    apidata = apidata,
            '    filenm = filenm,
            '    filetype = filetype,
            '    filesize = filesize,
            '    filedata = filedata,
            '};
            'db.tt_afgaibulog.INSERT.Execute(dto);
        End Sub
#End Region

#Region "宛名ログ"
        ''' <summary>
        ''' 宛名ログ
        ''' </summary>
        Public Shared Sub WriteAtenaLog(db As DaDbContext, atenano As String, Optional msg As String = "")
            'if (msg == "") msg = GetDisplayName();

            'tt_aflogatenaDto dto = new tt_aflogatenaDto();
            'dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
            'dto.atenano = atenano;
            'dto.usekbn = ((int)EnumAtenaActionType.検索).ToString();   //TODO
            'dto.msg = msg;
            'dto.reguserid = (string)db.Session.UserID!;
            'dto.regdttm = DaUtil.Now;
            'db.tt_aflogatena.INSERT.Execute(dto);
            Try
            Catch
            End Try
        End Sub
        ''' <summary>
        ''' 宛名ログ
        ''' </summary>
        Public Shared Sub WriteAtenaLog(db As DaDbContext, list As IList, Optional usekbn As EnumAtenaActionType = EnumAtenaActionType.検索, Optional pnouseflg As Boolean = False, Optional msg As String = "")
            'if (msg == "") msg = GetDisplayName();

            'var sesssionSeq = (long)db.Session.SessionData[DaConst.SessionID];
            'List<tt_aflogatenaDto> dtoList = new List<tt_aflogatenaDto>();
            'foreach (var item in list)
            '{
            '    tt_aflogatenaDto dto = new tt_aflogatenaDto();
            '    dto.sessionseq = sesssionSeq;
            '    var pi = item.GetType().GetProperty(nameof(tt_afatenaDto.atenano))!;
            '    dto.atenano = pi.GetValue(item).ToString()  "";
            '    dto.usekbn = ((int)usekbn).ToString();
            '    dto.pnouseflg = pnouseflg;
            '    dto.reguserid = (string)db.Session.UserID!;
            '    dto.regdttm = DaUtil.Now;
            '    dto.msg = msg;
            '    dtoList.Add(dto);
            '}
            'db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
            Try
            Catch
            End Try
        End Sub

        ''' <summary>
        ''' 宛名ログ
        ''' </summary>
        'Public Shared Sub WriteAtenaLog(db As DaDbContext, method As MethodBase, enumerable As IEnumerable, Optional usekbn As EnumAtenaActionType = EnumAtenaActionType.検索, Optional pnouseflg As Boolean = False, Optional msg As String = Nothing)
        '    'msg = string.IsNullOrEmpty(msg)  GetDisplayName(method) : msg;

        '    'var sesssionSeq = (long)db.Session.SessionData[DaConst.SessionID];
        '    'var dtoList = new List<tt_aflogatenaDto>();
        '    'foreach (var item in enumerable)
        '    '{
        '    '    var dto = new tt_aflogatenaDto();
        '    '    dto.sessionseq = sesssionSeq;
        '    '    var pi = item.GetType().GetProperty(nameof(tt_afatenaDto.atenano))!;
        '    '    dto.atenano = pi.GetValue(item).ToString()  string.Empty;
        '    '    dto.usekbn = EnumToStr(usekbn);
        '    '    dto.pnouseflg = pnouseflg;
        '    '    dto.reguserid = (string)db.Session.UserID!;
        '    '    dto.regdttm = DaUtil.Now;
        '    '    dto.msg = msg;
        '    '    dtoList.Add(dto);
        '    '}
        '    'db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
        '    Try
        '    Catch
        '    End Try
        'End Sub

        ''' <summary>
        ''' 宛名ログ
        ''' </summary>
        'Public Shared Sub WriteAtenaLog(db As DaDbContext, atenano As String, pnouseflg As Boolean, usekbn As EnumAtenaActionType, Optional msg As String = Nothing)
        '    'if (string.IsNullOrEmpty(msg)) msg = GetDisplayName();

        '    'tt_aflogatenaDto dto = new tt_aflogatenaDto();
        '    'dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
        '    'dto.atenano = atenano;
        '    'dto.usekbn = ((int)usekbn).ToString();
        '    'dto.pnouseflg = pnouseflg;
        '    'dto.msg = msg;
        '    'dto.reguserid = (string)db.Session.UserID!;
        '    'dto.regdttm = DaUtil.Now;
        '    'db.tt_aflogatena.INSERT.Execute(dto);
        '    Try
        '    Catch
        '    End Try
        'End Sub

        ''' <summary>
        ''' 宛名ログ
        ''' </summary>
        Public Shared Sub WriteAtenaLog(db As DaDbContext, dto As tt_aflogatenaDto)
            'db.tt_aflogatena.INSERT.Execute(dto);
        End Sub

        ''' <summary>
        ''' 宛名ログ(複数場合）
        ''' </summary>
        'Public Shared Sub AddAtenaLog(dtoList As List(Of tt_aflogatenaDto), atenano As String, usekbn As EnumAtenaActionType, Optional pnouseflg As Boolean = False, Optional msg As String = "")
        '    ' if (msg == "") msg = GetDisplayName();

        '    Dim dto As tt_aflogatenaDto = New tt_aflogatenaDto()
        '    dto.atenano = atenano
        '    dto.usekbn = CInt(usekbn).ToString()
        '    dto.pnouseflg = pnouseflg
        '    dto.regdttm = DaUtil.Now
        '    dto.msg = msg
        '    dtoList.Add(dto)
        'End Sub

        ''' <summary>
        ''' 宛名ログ（複数場合）
        ''' </summary>
        Public Shared Sub WriteAtenaLog(db As DaDbContext, dtoList As List(Of tt_aflogatenaDto))
            'var sesssionSeq = (long)db.Session.SessionData[DaConst.SessionID];
            'foreach (var dto in dtoList)
            '{
            '    dto.sessionseq = sesssionSeq;
            '    dto.reguserid = (string)db.Session.UserID!;
            '}
            'db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
        End Sub
#End Region

#Region "共通ログ"
        ''' <summary>
        ''' 汎用メッセージ出力。処理要のメッセージ、DEBUGメッセージに出力可。
        ''' </summary>
        'public static void WriteDbMessage(DaDbContext db, string msg)
        '{
        '    tt_aflogdbDto dto = new tt_aflogdbDto();
        '    dto.msg = msg;
        '    dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
        '    dto.reguserid = db.Session.UserID == null  DaConst.LOG_ERR_VALUE : db.Session.UserID.ToString()!;
        '    dto.regdttm = DaUtil.Now;
        '    InsertDto(db.Session, dto);
        '}
        ''' <summary>
        ''' 汎用メッセージ出力。処理要のメッセージ、DEBUGメッセージに出力可。
        ''' </summary>
        Public Shared Sub WriteDbMessage(db As DaDbContext, msg As String)
            Dim dto As tt_aflogdbDto = New tt_aflogdbDto()
            dto.msg = msg
            dto.sessionseq = db.Session.SessionData(DaConst.SessionID)
''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             dto.reguserid = db.Session.UserID == null ? BCC.Affect.DataAccess.DaConst.LOG_ERR_VALUE : db.Session.UserID.ToString()!
''' 
            dto.regdttm = DaUtil.Now
dto.reguserid = db.Session.UserID
DaDbLogService.InsertDto(db.Session, dto)
End Sub

'Private Shared Sub InsertDto(session As SessionContext, lst As List(Of tt_aflogcolumnDto))
'    Dim dt1 = Gettt_aflogcolumnDt(session)
'    AIplus.AIF.DBLib.AiDtoUtil.SetDataTable(lst, dt1)
'    DaDbUtil.BulkInsert(session, dt1, tt_aflogcolumnDto.TABLE_NAME, True)
'End Sub

        Private Shared Sub InsertDto(session As SessionContext, dto As tt_aflogdbDto)
            Dim dt = Gettt_aflogdbDt(session)
            Dim userId = session.UserID

            Dim _conn = session.Connection
            If _conn.State = Data.ConnectionState.Closed Then
                _conn.Open()
            End If
            Dim dblogseq = DateTime.Now.ToString("yyyyMMddHHmmssfff")
            Dim insertSql As String = "INSERT INTO tt_aflogdb (dblogseq, sessionseq, sql, msg, reguserid, regdttm ) VALUES ( :dblogseq, :sessionseq, :sql, :msg, :reguserid, :regdttm)"
            Dim insertParams As New List(Of OracleParameter) From {
                New OracleParameter("dblogseq", dblogseq),
                New OracleParameter("sessionseq", dto.sessionseq),
                New OracleParameter("sql", dto.sql ),
                New OracleParameter("msg", dto.msg),
                New OracleParameter("reguserid", dto.reguserid),
                New OracleParameter("regdttm", dto.regdttm)
            }
            Using cmd As New OracleCommand(insertSql, _conn)
                cmd.Parameters.AddRange(insertParams.ToArray())
Try
                    Dim result = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Throw
                End Try
            End Using

        End Sub

        Private Shared Sub InsertDto(session As SessionContext, dto As tt_aflogDto)
            Dim dt = Gettt_aflogdbDt(session)
            Dim userId = session.UserID

            Dim _conn = session.Connection
            If _conn.State = Data.ConnectionState.Closed Then
                _conn.Open()
            End If
            Dim insertSql As String = "INSERT INTO tt_aflog (sessionseq, syoridttmf, syoridttmt, milisec, statuscd, kinoid, service, method, methodnm, reguserid, regdttm ) VALUES ( :sessionseq, :syoridttmf, :syoridttmt, :milisec, :statuscd, :kinoid, :service, :method, :methodnm, :reguserid, :regdttm)"
            Dim insertParams As New List(Of OracleParameter) From {
                New OracleParameter("sessionseq", dto.sessionseq),
                New OracleParameter("syoridttmf", dto.syoridttmf),
                New OracleParameter("syoridttmt", dto.syoridttmt ),
                New OracleParameter("milisec", dto.milisec),
                New OracleParameter("statuscd", dto.statuscd),
                New OracleParameter("kinoid", dto.kinoid),
                New OracleParameter("service", dto.service),
                New OracleParameter("method", dto.method ),
                New OracleParameter("methodnm", dto.methodnm),
                New OracleParameter("reguserid", dto.reguserid),
                New OracleParameter("regdttm", dto.regdttm)
            }
            Using cmd As New OracleCommand(insertSql, _conn)
                cmd.Parameters.AddRange(insertParams.ToArray())
Try
                    Dim result = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Throw
                End Try
            End Using

        End Sub

        Private Shared Sub InsertDto(session As SessionContext, dto As tt_aftusinlogDto)
            Dim dt = Gettt_aflogdbDt(session)
            Dim userId = session.UserID

            Dim _conn = session.Connection
            If _conn.State = Data.ConnectionState.Closed Then
                _conn.Open()
            End If
            Dim dblogseq = DateTime.Now.ToString("yyyyMMddHHmmssfff")
            Dim insertSql As String = "INSERT INTO tt_aftusinlog (tusinlogseq, sessionseq, syoridttmf, syoridttmt, msg, request, response , ipadrs, os, browser,  reguserid, regdttm ) VALUES ( :tusinlogseq, :sessionseq, :syoridttmf, :syoridttmt, :msg, :request, :response , :ipadrs, :os, :browser, :reguserid, :regdttm)"
            Dim insertParams As New List(Of OracleParameter) From {
                New OracleParameter("tusinlogseq", dblogseq),
                New OracleParameter("sessionseq", dto.sessionseq),
                New OracleParameter("syoridttmf", dto.syoridttmf ),
                New OracleParameter("syoridttmt", dto.syoridttmt),
                New OracleParameter("msg", dto.msg),
                New OracleParameter("request", dto.request),
                New OracleParameter("response", dto.response),
                New OracleParameter("ipadrs", dto.ipadrs),
                New OracleParameter("os", dto.os),
                New OracleParameter("browser", dto.browser),
                New OracleParameter("reguserid", dto.reguserid),
                New OracleParameter("regdttm", dto.regdttm)
            }
            Using cmd As New OracleCommand(insertSql, _conn)
                cmd.Parameters.AddRange(insertParams.ToArray())
Try
                    Dim result = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Throw
                End Try
            End Using

        End Sub

        ''' <summary>
        ''' 汎用例外メッセージ出力
        ''' </summary>
        Public Shared Sub WriteDbException(db As DaDbContext, ex As Exception)
            Try
                Dim dto As tt_aflogdbDto = New tt_aflogdbDto()
                dto.msg = $"{ex.Message} {ex.StackTrace}"
''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 

                dto.reguserid = db.Session.UserID.ToString()
''' 
dto.regdttm = DaUtil.Now
DaDbLogService.InsertDto(db.Session, dto)
Catch
End Try
End Sub


'''' <summary>
'''' 汎用例外メッセージ出力
'''' </summary>
'public static void WriteDbException(DaDbContext db, Exception ex)
'{
'    try
'    {
'        tt_aflogdbDto dto = new tt_aflogdbDto();
'        dto.msg = $"{ex.Message} {ex.StackTrace}";
'        dto.reguserid = db.Session.UserID!.ToString()!;
'        dto.regdttm = DaUtil.Now;
'        InsertDto(db.Session, dto);
'    }
'    catch { }
'}

''' <summary>
''' DBログ処理
''' </summary>
'public static void LogDelegate(AiSessionContext session, DateTime beginTime, DateTime endTime, string sql, DataTable dt, int result)
'{
'    if (dt != null && (dt.TableName == tt_aflogDto.TABLE_NAME
'        || dt.TableName == tt_aftusinlogDto.TABLE_NAME
'        || dt.TableName == tt_afbatchlogDto.TABLE_NAME
'        || dt.TableName == tt_afgaibulogDto.TABLE_NAME
'        || dt.TableName == tt_aflogatenaDto.TABLE_NAME
'        || dt.TableName == tt_aflogdbDto.TABLE_NAME
'        || dt.TableName == tt_aflogcolumnDto.TABLE_NAME))
'    {
'        return;
'    }
'    if (session == null || (long)session.SessionData[DaConst.SessionID] == 0L || (long)session.SessionData[DaConst.SessionID] == -1L)
'    {
'        return;
'    }
'    if (sql.Contains("information_schema")) return;

'    var dto = new tt_aflogdbDto();
'    dto.sessionseq = (long)session.SessionData[DaConst.SessionID];
'    if (session.SessionData != null && session.SessionData.Any())
'    {
'        var userId = session.UserID;
'        dto.reguserid = userId == null  DaConst.LOG_ERR_VALUE : userId.ToString()!;
'    }
'    else
'    {
'        dto.reguserid = DaConst.LOG_ERR_VALUE;
'    }
'    dto.regdttm = DaUtil.Now;
'    dto.sql = sql;

'    InsertDto(session, dto);
'}

''' <summary>
''' 更新項目処理
''' </summary>
'public static void DiffDelegate(AiSessionContext session, string tableName, EnumActionType diffType, DataTable oldDt, DataTable newDt, object param)
'{
'    if (tableName == tt_aflogDto.TABLE_NAME
'        || tableName == tt_aftusinlogDto.TABLE_NAME
'        || tableName == tt_afbatchlogDto.TABLE_NAME
'        || tableName == tt_afgaibulogDto.TABLE_NAME
'        || tableName == tt_aflogatenaDto.TABLE_NAME
'        || session == null || (long)session.SessionData[DaConst.SessionID] == 0L || (long)session.SessionData[DaConst.SessionID] == -1L)
'    {
'        return;
'    }
'    List<tt_aflogcolumnDto> lst;
'    var tableInfo = AiGlobal.DbInfoProvider.GetTableInfo(session, tableName);

'    switch (diffType)
'    {
'        case EnumActionType.Insert:
'            {
'                lst = AddList(tableName, session, newDt, tableInfo);
'                //宛名ログ
'                if (param != null)
'                {
'                    AtenaLog(session, diffType, newDt, param);
'                }
'                break;
'            }
'        case EnumActionType.Update:
'            {
'                lst = UpdList(tableName, session, oldDt, newDt, tableInfo);
'                //宛名ログ
'                if (param != null && param.GetType() == typeof(List<string>))
'                {
'                    AtenaLog(session, diffType, newDt, param);
'                }
'                break;
'            }

'        default:
'            {
'                lst = DelList(tableName, session, oldDt, tableInfo);
'                //宛名ログ
'                if (param != null)
'                {
'                    AtenaLog(session, diffType, oldDt, param);
'                }
'                break;
'            }
'    }

'    if (session is not null)
'    {
'        foreach (var row in lst)
'        {
'            row.reguserid = (string)session.UserID!;
'            row.regdttm = DaUtil.Now;
'        }
'    }

'    InsertDto(session!, lst);
'}

'private static void AtenaLog(AiSessionContext session, EnumActionType diffType, DataTable dt, object param)
'{
'    if (session.DbContext == null) throw new ArgumentException();
'    if (param == null) throw new ArgumentException(); ;

'    var dtoList = new List<tt_aflogatenaDto>();
'    List<string> pnoDic;
'    if (param.GetType() == typeof(object))
'    {
'        pnoDic = new List<string>();
'    }
'    else
'    {
'        pnoDic = (List<string>)param;
'    }

'    var listkey = nameof(AtenaLog) + diffType.ToString();
'    if (session.SessionData.ContainsKey(listkey)==false)
'    {
'        session.SessionData.Add(listkey, new HashSet<string>());
'    }
'    HashSet<string> lst = (HashSet<string>)session.SessionData[listkey];
'    foreach (DataRow dr in dt.Rows)
'    {
'        tt_aflogatenaDto dto = new tt_aflogatenaDto();
'        dto.atenano = dr["atenano"].ToString()!;
'        //１個のSession内、同じ宛名のログを１個のみ出力する
'        if (lst.Contains(dto.atenano) == false)
'        {
'            dto.usekbn = diffType switch { EnumActionType.Insert => "1", EnumActionType.Update => "2", EnumActionType.Delete => "3", _ => throw new ArgumentException() };
'            dto.pnouseflg = pnoDic.Contains(dto.atenano);
'            dto.regdttm = DaUtil.Now;
'            //dto.msg = msg;
'            dtoList.Add(dto);

'            lst.Add(dto.atenano);   
'        }
'    }

'    var db = (DaDbContext)session.DbContext!;
'    db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
'}

'public static void WriteService(DaDbContext db, tt_aflogdbDto dto)
'{
'    try
'    {
'        InsertDto(db.Session, dto);
'    }
'    catch { }
'}
#End Region
#Region "private"

'private static void InsertDto(AiSessionContext session, List<tt_aflogcolumnDto> lst)
'{
'    var dt1 = Gettt_aflogcolumnDt(session);
'    AiDtoUtil.SetDataTable(lst, dt1);
'    DaDbUtil.BulkInsert(session, dt1, tt_aflogcolumnDto.TABLE_NAME, true);
'}

'private static List<tt_aflogcolumnDto> AddList(string tablename, AiSessionContext session, DataTable dt, AiTableInfo tableInfo)
'{
'    var lst = new List<tt_aflogcolumnDto>();
'    var tm = DaUtil.Now;
'    //string reguserid = dt.Rows[0].ToStr(nameof(tm_afuserDto.upduserid));
'    var keys = tableInfo.KeyList.Select(e => e.FieldName).ToList();
'    foreach (DataRow dr in dt.Rows)
'    {
'        lst.AddRange(GetAddList(tablename, keys, tm, session, dr));
'    }
'    return lst;
'}

'private static List<tt_aflogcolumnDto> UpdList(string tablename, AiSessionContext session, DataTable olddt, DataTable newDt, AiTableInfo tableInfo)
'{
'    var tm = DaUtil.Now;
'    var lst = new List<tt_aflogcolumnDto>();
'    //string reguserid ="";
'    //if (newDt.Rows.Count > 0)
'    //{
'    //    if (newDt.Rows[0].ToStr(nameof(tm_afuserDto.upduserid)) !="")
'    //    {
'    //        reguserid = newDt.Rows[0].ToStr(nameof(tm_afuserDto.reguserid));
'    //    }
'    //}
'    var dic1 = new Dictionary<string, DataRow>();
'    var keys = tableInfo.KeyList.Select(e => e.FieldName).ToList();
'    foreach (DataRow dr in olddt.Rows)
'    {
'        string[] keyValues = keys.Select(e => dr.CStr(e)).ToArray();
'        string keyData = string.Join(",", keyValues);
'        dic1.Add(keyData, dr);
'    }

'    var dic2 = new Dictionary<string, DataRow>();
'    foreach (DataRow dr in newDt.Rows)
'    {
'        string[] keyValues = keys.Select(e => dr.CStr(e)).ToArray();
'        string keyData = string.Join(",", keyValues);
'        dic2.Add(keyData, dr);
'    }

'    // 更新
'    foreach (var key in dic1.Keys)
'    {
'        if (dic2.ContainsKey(key))
'        {
'            lst.AddRange(GetUpdList(tablename, keys, tm, session, dic1[key], dic2[key]));
'        }
'    }

'    // 新規
'    foreach (var key in dic2.Keys)
'    {
'        if (dic1.ContainsKey(key) == false)
'        {
'            lst.AddRange(GetAddList(tablename, keys, tm, session, dic2[key]));
'        }
'    }

'    // 削除
'    foreach (var key in dic1.Keys)
'    {
'        if (dic2.ContainsKey(key) == false)
'        {
'            lst.AddRange(GetDelList(tablename, keys, tm, session, dic1[key]));
'        }
'    }

'    return lst;
'}

'private static List<tt_aflogcolumnDto> DelList(string tablename, AiSessionContext session, DataTable dt, AiTableInfo tableInfo)
'{
'    var lst = new List<tt_aflogcolumnDto>();
'    var tm = DaUtil.Now;
'    var keys = tableInfo.KeyList.Select(e => e.FieldName).ToList();
'    foreach (DataRow dr in dt.Rows)
'    {
'        lst.AddRange(GetDelList(tablename, keys, tm, session, dr));
'    }

'    return lst;
'}
'private static List<tt_aflogcolumnDto> GetAddList(string tableName, List<string> keys, DateTime tm, AiSessionContext session, DataRow dr)
'{
'    var lst = new List<tt_aflogcolumnDto>();
'    string[] keyValues = keys.Select(e => dr[e].ToString()  string.Empty).ToArray();
'    string keyData = string.Join(",", keyValues);
'    for (int i = 0; i< dr.Table.Columns.Count ; i++)
'    {
'        var col = dr.Table.Columns[i];
'        switch (col.ColumnName  string.Empty)
'        {
'            case nameof(tm_afuserDto.reguserid):
'            case nameof(tm_afuserDto.regdttm):
'            case nameof(tm_afuserDto.upduserid):
'            case nameof(tm_afuserDto.upddttm):
'                {
'                    continue;
'                }
'        }
'        string value = dr[i].ToString()  string.Empty;
'        if (!string.IsNullOrEmpty(value))
'        {
'            for (int c = 0; c< value.Length; c += MAX_CHARS)
'            {
'                var dto = new tt_aflogcolumnDto();
'                dto.sessionseq =(session.SessionData.ContainsKey(DaConst.SessionID))
'                                (long)session.SessionData[DaConst.SessionID]:-1;                        // セッションID
'                dto.regdttm = tm;                                         // 時刻
'                dto.tablenm = tableName;                                  // テーブル名
'                dto.henkokbn = ((int)EnumActionType.Insert).ToString();   // 更新区分
'                dto.reguserid = session.UserID == null  DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
'                if (dto.reguserid.Length > 10)
'                {
'                    dto.reguserid = DaConst.LOG_ERR_VALUE;
'                }

'                dto.keys = keyData;                  　                 // キー
'                dto.itemnm = dr.Table.Columns[i].ColumnName;            // 項目名
'                dto.valuebefore = null;                            　　 // 変更前内容
'                dto.valueafter = new string(value.Skip(c).Take(MAX_CHARS).ToArray());
'                lst.Add(dto);
'            }
'        }
'    }

'    return lst;
'}

'private static List<tt_aflogcolumnDto> GetDelList(string tableName, List<string> keys, DateTime tm, AiSessionContext session, DataRow dr)
'{
'    var isLogKey = false;
'    if (isLogKey)
'    {
'        //レコード単位のログ
'        var lst = new List<tt_aflogcolumnDto>();

'        string[] keyValues = keys.Select(e => dr.CStr(e)).ToArray();
'        string keyData = string.Join(",", keyValues);
'        var dto = new tt_aflogcolumnDto();
'        dto.sessionseq = (long)session.SessionData[DaConst.SessionID];                        // セッションID
'        dto.regdttm = tm;                                         // 時刻
'        dto.tablenm = tableName;                                  // テーブル名
'        dto.henkokbn = ((int)EnumActionType.Delete).ToString();   // 更新区分
'        dto.reguserid = session.UserID == null  DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
'        if (dto.reguserid.Length > 10)
'        {
'            dto.reguserid = DaConst.LOG_ERR_VALUE;
'        }

'        dto.keys = keyData;                                     // キー
'        lst.Add(dto);

'        return lst;
'    }
'    else
'    {
'        //各項目単位でのログ出力
'        var lst = new List<tt_aflogcolumnDto>();
'        string[] keyValues = keys.Select(e => dr[e].ToString()  string.Empty).ToArray();
'        string keyData = string.Join(",", keyValues);
'        for (int i = 0; i < dr.Table.Columns.Count; i++)
'        {
'            var col = dr.Table.Columns[i];
'            switch (col.ColumnName  string.Empty)
'            {
'                case nameof(tm_afuserDto.reguserid):
'                case nameof(tm_afuserDto.regdttm):
'                case nameof(tm_afuserDto.upduserid):
'                case nameof(tm_afuserDto.upddttm):
'                    {
'                        continue;
'                    }
'            }
'            string value = dr[i].ToString()  string.Empty;
'            if (!string.IsNullOrEmpty(value))
'            {
'                for (int c = 0; c < value.Length; c += MAX_CHARS)
'                {
'                    var dto = new tt_aflogcolumnDto();
'                    dto.sessionseq = (session.SessionData.ContainsKey(DaConst.SessionID)) 
'                                    (long)session.SessionData[DaConst.SessionID] : -1;                        // セッションID
'                    dto.regdttm = tm;                                         // 時刻
'                    dto.tablenm = tableName;                                  // テーブル名
'                    dto.henkokbn = ((int)EnumActionType.Delete).ToString();   // 更新区分
'                    dto.reguserid = session.UserID == null  DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
'                    if (dto.reguserid.Length > 10)
'                    {
'                        dto.reguserid = DaConst.LOG_ERR_VALUE;
'                    }

'                    dto.keys = keyData;                                    // キー
'                    dto.itemnm = dr.Table.Columns[i].ColumnName;            // 項目名
'                    dto.valuebefore = null;                               // 変更前内容
'                    dto.valueafter = new string(value.Skip(c).Take(120).ToArray());
'                    lst.Add(dto);
'                }
'            }
'        }

'        return lst;

'    }
'}

'private static List<tt_aflogcolumnDto> GetUpdList(string tableName, List<string> keys, DateTime tm, AiSessionContext session, DataRow dr1, DataRow dr2)
'{
'    var lst = new List<tt_aflogcolumnDto>();
'    for (int i = 0; i < dr1.Table.Columns.Count; i++)
'    {
'        string[] keyValues = keys.Select(e => dr1[e].ToString()  string.Empty).ToArray();
'        string keyData = string.Join(",", keyValues);
'        var col = dr1.Table.Columns[i];
'        switch (col.ColumnName  string.Empty)
'        {
'            case nameof(tm_afuserDto.reguserid):
'            case nameof(tm_afuserDto.regdttm):
'            case nameof(tm_afuserDto.upduserid):
'            case nameof(tm_afuserDto.upddttm):
'                {
'                    continue;
'                }
'        }
'        string value1 = dr1[i].ToString()  string.Empty.Trim();
'        string value2 = dr2[i].ToString()  string.Empty.Trim();
'        if ((value1  string.Empty) != (value2  string.Empty))
'        {
'            for (int c = 0, loopTo1 = Math.Max(value1!.Length, value2!.Length); c <= loopTo1; c += MAX_CHARS)
'            {
'                var dto = new tt_aflogcolumnDto();
'                dto.sessionseq = (long)session.SessionData[DaConst.SessionID];                      // セッションID
'                dto.regdttm = tm;                                       // 時刻
'                dto.tablenm = tableName;                                  // テーブル名
'                dto.henkokbn = ((int)EnumActionType.Update).ToString();   // 更新区分
'                dto.reguserid = session.UserID == null  DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
'                if (dto.reguserid.Length > 10)
'                {
'                    dto.reguserid = DaConst.LOG_ERR_VALUE;
'                }
'                dto.keys = keyData;                                     // キー
'                dto.itemnm = dr1.Table.Columns[i].ColumnName;           // 項目名
'                dto.valuebefore = new string(value1.Skip(c).Take(MAX_CHARS).ToArray()); // 変更前内容
'                dto.valueafter = new string(value2.Skip(c).Take(MAX_CHARS).ToArray());
'                lst.Add(dto);
'            }
'        }
'    }
'    return lst;
'}

'private static void InsertDto(AiSessionContext session, tt_aflogdbDto dto)
'{
'    var dt = Gettt_aflogdbDt(session);
'    var userId = session.UserID;
'    dto.reguserid = userId == null  DaConst.LOG_ERR_VALUE : userId.ToString()!;
'    dto.regdttm = DaUtil.Now;
'    AiDtoUtil.SetDataTable(dto, dt);
'    DaDbUtil.BulkInsert(session, dt, tt_aflogdbDto.TABLE_NAME, true);
'}

'private static string GetDisplayName(MethodBase method = null)
'{
'    try
'    {
'        method = new StackTrace().GetFrame(2).GetMethod()!;
'        var attribute = method.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
'        return attribute.DisplayName;
'    }
'    catch
'    {
'        return string.Empty;
'    }
'}

'''' <summary>
'''' メインログテーブルDataTable作成
'''' </summary>
'private static DataTable Gettt_aflogDt()
'{
'    var dt = new DataTable();
'    dt.Columns.Add(nameof(tt_aflogDto.sessionseq), typeof(long));
'    dt.Columns.Add(nameof(tt_aflogDto.syoridttmf), typeof(DateTime));
'    dt.Columns.Add(nameof(tt_aflogDto.syoridttmt), typeof(DateTime));
'    dt.Columns.Add(nameof(tt_aflogDto.milisec), typeof(int));
'    dt.Columns.Add(nameof(tt_aflogDto.statuscd));
'    dt.Columns.Add(nameof(tt_aflogDto.kinoid));
'    dt.Columns.Add(nameof(tt_aflogDto.service));
'    dt.Columns.Add(nameof(tt_aflogDto.method));
'    dt.Columns.Add(nameof(tt_aflogDto.methodnm));
'    dt.Columns.Add(nameof(tt_aflogDto.reguserid));
'    dt.Columns.Add(nameof(tt_aflogDto.regdttm), typeof(DateTime));
'    return dt;
'}

'''' <summary>
'''' 通信ログテーブルDataTable作成
'''' </summary>
'private static DataTable Gettt_aftusinlogDt()
'{
'    DataTable dt = new DataTable();
'    dt.Columns.Add(nameof(tt_aftusinlogDto.tusinlogseq), typeof(long));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.sessionseq), typeof(long));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.syoridttmf), typeof(DateTime));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.msg));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.request));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.response));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.ipadrs));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.os));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.browser));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.reguserid));
'    dt.Columns.Add(nameof(tt_aftusinlogDto.regdttm), typeof(DateTime));
'    return dt;
'}

'''' <summary>
'''' バッチログテーブルDataTable作成
'''' </summary>
'private static DataTable Gettt_afbatchlogDt()
'{
'    DataTable dt = new DataTable();
'    dt.Columns.Add(nameof(tt_afbatchlogDto.batchlogseq), typeof(long));
'    dt.Columns.Add(nameof(tt_afbatchlogDto.sessionseq), typeof(long));
'    dt.Columns.Add(nameof(tt_afbatchlogDto.syoridttmf), typeof(DateTime));
'    dt.Columns.Add(nameof(tt_afbatchlogDto.msg));
'    dt.Columns.Add(nameof(tt_afbatchlogDto.pram));
'    dt.Columns.Add(nameof(tt_afbatchlogDto.reguserid));
'    dt.Columns.Add(nameof(tt_afbatchlogDto.regdttm), typeof(DateTime));

'    return dt;
'}

'''' <summary>
'''' 外部連携処理結果履歴テーブルDataTable作成
'''' </summary>
'private static DataTable Gettt_afgaibulogDt()
'{
'    DataTable dt = new DataTable();
'    dt.Columns.Add(nameof(tt_afgaibulogDto.gaibulogseq), typeof(int));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.sessionseq), typeof(long));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.syoridttmf), typeof(DateTime));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.msg));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.ipadrs));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.kbn));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.kbn2));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.apidata));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.filenm));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.filetype), typeof(short));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.filesize), typeof(int));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.filedata));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.reguserid));
'    dt.Columns.Add(nameof(tt_afgaibulogDto.regdttm), typeof(DateTime));

'    return dt;
'}

'''' <summary>
'''' 宛名番号ログテーブルテーブルDataTable作成
'''' </summary>
'private static DataTable Gettt_aflogatenaDt()
'{
'    DataTable dt = new DataTable();
'    dt.Columns.Add(nameof(tt_aflogatenaDto.atenalogseq), typeof(int));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.sessionseq), typeof(long));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.atenano));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.pnouseflg), typeof(bool));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.usekbn));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.msg));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.reguserid));
'    dt.Columns.Add(nameof(tt_aflogatenaDto.regdttm), typeof(DateTime));

'    return dt;
'}


'''' <summary>
'''' DB操作ログテーブルDataTable作成
'''' </summary>
'private static DataTable Gettt_aflogdbDt(AiSessionContext session)
'{
'    var dt = new DataTable();
'    dt.Columns.Add(nameof(tt_aflogdbDto.dblogseq), typeof(long));
'    dt.Columns.Add(nameof(tt_aflogdbDto.sessionseq), typeof(long));
'    dt.Columns.Add(nameof(tt_aflogdbDto.sql), typeof(string));
'    dt.Columns.Add(nameof(tt_aflogdbDto.msg), typeof(string));
'    dt.Columns.Add(nameof(tt_aflogdbDto.reguserid), typeof(string));
'    dt.Columns.Add(nameof(tt_aflogdbDto.regdttm), typeof(DateTime));
'    return dt;
'}
''' <summary>
''' DB操作ログテーブルDataTable作成
''' </summary>
        Private Shared Function Gettt_aflogdbDt(session As SessionContext) As Data.DataTable
            Dim dt = New Data.DataTable()
            dt.Columns.Add(NameOf(tt_aflogdbDto.dblogseq), GetType(Long))
            dt.Columns.Add(NameOf(tt_aflogdbDto.sessionseq), GetType(Long))
            dt.Columns.Add(NameOf(tt_aflogdbDto.sql), GetType(String))
            dt.Columns.Add(NameOf(tt_aflogdbDto.msg), GetType(String))
            dt.Columns.Add(NameOf(tt_aflogdbDto.reguserid), GetType(String))
            dt.Columns.Add(NameOf(tt_aflogdbDto.regdttm), GetType(Date))
            Return dt
        End Function

        '''' <summary>
        '''' テーブル項目値変更ログテーブルDataTable作成
        '''' </summary>
        'private static DataTable Gettt_aflogcolumnDt(AiSessionContext session)
        '{
        '    var dt = new DataTable();
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.columnlogseq), typeof(long));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.sessionseq), typeof(long));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.tablenm), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.henkokbn), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.keys), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.itemnm), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.valuebefore), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.valueafter), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.reguserid), typeof(string));
        '    dt.Columns.Add(nameof(tt_aflogcolumnDto.regdttm), typeof(DateTime));
        '    return dt;
        '}

#End Region
    End Class
End Namespace
