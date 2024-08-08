' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ドロップダウンリスト
'
' 作成日　　: 2024.07.14
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports Microsoft.Extensions.Caching.Memory

Namespace JBD.GJS.Db
    Public Module DaSelectorService
        Private _cache As MemoryCache
        Const CACHE_MINIUTE As Integer = 5

        Public Sub ClearCache()
            _cache.Clear()
            Call DaNameService.ClearCache()
            Call DaControlService.ClearCache()

        End Sub

        Public Function GetSelectorList(db As DaDbContext, kbn1 As Enum名称区分, kbn2 As Enumシステムマスタ区分, ParamArray keys As String()) As List(Of DaSelectorModel)
            'キャッシュ初期化
            If _cache Is Nothing Then
                _cache = New MemoryCache(New MemoryCacheOptions())
            End If
            Select Case kbn2
                'Case Enumシステムマスタ区分.名称メインマスタ
                '    Dim keyvalue = If(keys.Length = 1, keys(0), CSharpImpl.__Throw(Of String)(New ArgumentException()))
                '    Dim key = $"{kbn2}{keyvalue}"
                '    Dim name As String
                '    Select Case kbn1
                '        Case Enum名称区分.名称
                '            name = NameOf(tm_afmeisyo_mainDto.nmsubcdnm)
                '        Case Enum名称区分.カナ
                '            name = NameOf(tm_afmeisyo_mainDto.kananm)
                '        Case Enum名称区分.略称
                '            name = NameOf(tm_afmeisyo_mainDto.shortnm)
                '        Case Else
                '            Throw New ArgumentException()
                '    End Select
                '    Dim sql = $"select cast(nmsubcd as varchar) {NameOf(DaSelectorModel.value)}, 
                '                        {name} {NameOf(DaSelectorModel.label)} 
                '                 from {tm_afmeisyo_mainDto.TABLE_NAME}
                '                 where nmmaincd='{keyvalue}'
                '                 order by nmsubcd"

                '    Return GetSelectList(db, key, sql)
                'Case Enumシステムマスタ区分.汎用メインマスタ
                '    Dim keyvalue = If(keys.Length = 1, keys(0), CSharpImpl.__Throw(Of String)(New ArgumentException()))
                '    Dim key = $"{kbn2}{keyvalue}"
                '    Dim name As String
                '    Select Case kbn1
                '        Case Enum名称区分.名称
                '            name = NameOf(tm_afhanyo_mainDto.hanyosubcdnm)
                '        Case Enum名称区分.カナ
                '            name = NameOf(tm_afhanyo_mainDto.kananm)
                '        Case Enum名称区分.略称
                '            name = NameOf(tm_afhanyo_mainDto.shortnm)
                '        Case Else
                '            Throw New ArgumentException()
                '    End Select
                '    Dim sql = $"select cast(hanyosubcd as varchar) {NameOf(DaSelectorModel.value)}, 
                '                        {name} {NameOf(DaSelectorModel.label)} 
                '                 from {tm_afhanyo_mainDto.TABLE_NAME}
                '                 where hanyomaincd='{keyvalue}'
                '                 order by hanyosubcd"
                '    Return GetSelectList(db, key, sql)

                'Case Enumシステムマスタ区分.EUCテーブルマスタ
                '    Dim key = $"{kbn2}"
                '    Dim sql = GetSelectSQL(tm_eutableDto.TABLE_NAME, NameOf(tm_eutableDto.tablenm), NameOf(tm_eutableDto.tablehyojinm), $"", NameOf(tm_eutableDto.orderseq))
                '    Return GetSelectList(db, key, sql)

                'Case Enumシステムマスタ区分.機能マスタ
                '    Dim key = $"{kbn2}"
                '    Dim sql = GetSelectSQL(tm_afkinoDto.TABLE_NAME, NameOf(tm_afkinoDto.kinoid), NameOf(tm_afkinoDto.hyojinm), $"", NameOf(tm_afkinoDto.kinoid))
                '    Return GetSelectList(db, key, sql)

                'Case Enumシステムマスタ区分.タスクスケジュール情報マスタ
                '    Dim key = $"{kbn2}{kbn1}"

                '    Dim sql = GetSelectSQL(tm_aftaskscheduleDto.TABLE_NAME, NameOf(tm_aftaskscheduleDto.taskid), NameOf(tm_aftaskscheduleDto.tasknm))
                '    Return GetSelectList(db, key, sql)

                'case Enumシステムマスタ区分.EUC帳票マスタ:
                '    {
                '        string key = $"{kbn2}{kbn1}";

                '        string sql = GetSelectSQL(tm_eurptDto.TABLE_NAME,
                '                                nameof(tm_eurptDto.rptid),
                '                                nameof(tm_eurptDto.rptnm)
                '                                );
                '        return GetSelectList(db, key, sql);
                '    }

                'Case Enumシステムマスタ区分.EUC様式詳細マスタ
                '    Dim key = $"{kbn2}{kbn1}"

                '    Dim sql = GetSelectSQL(tm_euyosikisyosaiDto.TABLE_NAME, NameOf(tm_euyosikisyosaiDto.yosikiid), NameOf(tm_euyosikisyosaiDto.yosikinm))
                '    Return GetSelectList(db, key, sql)

                'Case Enumシステムマスタ区分.帳票発行抽出対象マスタ
                '    Dim key = $"{kbn2}{kbn1}"

                '    Dim sql = GetSelectSQL(tm_afrpthakkotyusyututaisyoDto.TABLE_NAME, NameOf(tm_afrpthakkotyusyututaisyoDto.taisyocd), NameOf(tm_afrpthakkotyusyututaisyoDto.taisyonm))
                '    'todo
                '    Return GetSelectList(db, key, sql)
                Case Else
                    Throw New Exception("Enumマスタ区分 error")
            End Select
        End Function

        ''' <summary>
        ''' 表記取得(コード：名称)
        ''' </summary>
        Public Function GetCdNm(db As DaDbContext, code As String, kbn1 As Enum名称区分, kbn2 As Enumマスタ区分, ParamArray keys As String()) As String
            If String.IsNullOrEmpty(code) Then
                Return String.Empty
            End If
            Return String.Empty
            'Return GetCodeName(db, code, kbn1, kbn2, keys)
        End Function

        ''' <summary>
        ''' 表記取得(コード：名称)
        ''' </summary>
        Public Function GetCdNm(list As List(Of DaSelectorModel), code As String) As String
            If String.IsNullOrEmpty(code) Then
                Return String.Empty
            End If
            Dim name = list.Find(Function(e) Equals(e.value, code))
            If name Is Nothing Then Return $"{code}{DaConst.SELECTOR_DELIMITER}"
            Return $"{code}{DaConst.SELECTOR_DELIMITER}{name.label}"
        End Function

        'Public Function GetName(db As DaDbContext, code As String, kbn1 As Enum名称区分, kbn2 As Enumマスタ区分, ParamArray keys As String()) As String
        '    If String.IsNullOrEmpty(code) Then
        '        Return String.Empty
        '    End If

        '    'Dim list = DaSelectorServiceHelpers.GetSelectorList(db, kbn1, kbn2, True, keys)
        '    Return GetName(List As , code)
        'End Function

        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetName(list As List(Of DaSelectorModel), code As String) As String
            Dim row = list.Find(Function(e) Equals(e.value, code))
            Return If(row Is Nothing, String.Empty, row.label)
        End Function

        ''' <summary>
        ''' コード取得
        ''' </summary>
        Public Function GetCd(CdNm As String) As String
            Return If(String.IsNullOrEmpty(CdNm), String.Empty, CdNm.Split(DaConst.SELECTOR_DELIMITER)(0))
        End Function

        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Function GetName(CdNm As String) As String
            If String.IsNullOrEmpty(CdNm) Then
                Return String.Empty
            End If
            Return CdNm.Split(DaConst.SELECTOR_DELIMITER)(1)
        End Function

        ''' <summary>
        ''' コード：名称の取得
        ''' </summary>
        'Private Function GetCodeName(db As DaDbContext, cd As String, kbn1 As Enum名称区分, kbn2 As Enumマスタ区分, ParamArray keys As String()) As String
        '    Dim list = DaSelectorServiceHelpers.GetSelectorList(db, kbn1, kbn2, True, keys)
        '    Return GetCdNm(list, cd)
        'End Function

        ''' <summary>
        ''' SQLの組み込み
        ''' </summary>
        Private Function GetSelectSQL(table As String, cd As String, name As String, Optional where As String = "", Optional orderby As String = "") As String
            Dim order = If(String.IsNullOrEmpty(orderby), cd, orderby)
            If String.IsNullOrEmpty(where) Then
                Return $"select {cd} {NameOf(DaSelectorModel.value)}, {name} {NameOf(DaSelectorModel.label)} from {table} order by {order}"
            Else
                Return $"select {cd} {NameOf(DaSelectorModel.value)}, {name} {NameOf(DaSelectorModel.label)} from {table} where {where} order by {order}"
            End If
        End Function

        ''' <summary>
        ''' キャッシュ化一覧の取得
        ''' </summary>
'        Private Function GetSelectList(db As DaDbContext, key As String, sql As String) As List(Of DaSelectorModel)
'            'data = db.Session.Query<DaSelectorModel>(sql);
'            Dim data As List(Of DaSelectorModel)
'                        ''' Cannot convert IfStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
''''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitIfStatement(IfStatementSyntax node)
''''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
''''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
'''' 
'''' Input:
''''             if (!JBD.GJS.Db.DaSelectorService._cache.TryGetValue(key, out data!))
''''             {
''''                 //data = db.Session.Query<DaSelectorModel>(sql);
''''                 JBD.GJS.Db.DaSelectorService._cache.Set(key, data, System.TimeSpan.FromMinutes(JBD.GJS.Db.DaSelectorService.CACHE_MINIUTE));
''''             }
'''' 
'''' 
'            Return data
'        End Function
        ''' <summary>
        ''' 使用停止sql
        ''' </summary>
        Private Function GetStopFlgWhereSql(hasStopFlg As Boolean, flgNm As String, Optional tbId As String = Nothing) As String
            Dim where = String.Empty
            If Not hasStopFlg Then
                Dim tbIdSql = If(String.IsNullOrEmpty(tbId), String.Empty, $"{tbId}.")
                where = $" and {tbIdSql}{flgNm} = false"
            End If
            Return where
        End Function

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal throw statements")>
            Shared Function __Throw(Of T)(ByVal e As Exception) As T
                Throw e
            End Function
        End Class
    End Module
End Namespace
