' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 名称マスタ
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaNameService
        Private Shared _cache As MemoryCache
        Const CACHE_MINIUTE As Integer = 5
        Public Const MAINCODE_DIGIT As Long = 100000000L

        ''' <summary>
        ''' キャシュークリア
        ''' </summary>
        Public Shared Sub ClearCache()
            _cache.Clear()
        End Sub

        ''' <summary>
        ''' ドロップダウンリスト取得
        ''' </summary>
        Public Shared Function GetSelectorList(db As DaDbContext, nmKbn As EnumNmKbn, kbn As Enum名称区分) As List(Of DaSelectorModel)
            Return DaSelectorService.GetSelectorList(db, kbn, Enumシステムマスタ区分.名称メインマスタ, CLng(nmKbn).ToString())
        End Function

        ''' <summary>
        ''' ドロップダウンリスト取得
        ''' </summary>
        Public Shared Function GetSelectorList(db As DaDbContext, maincd As String, subcd As Integer, kbn As Enum名称区分) As List(Of DaSelectorModel)
            Return DaSelectorService.GetSelectorList(db, kbn, Enumシステムマスタ区分.名称メインマスタ, maincd, subcd.ToString())
        End Function

        ''' <summary>
        ''' ドロップダウンリスト取得
        ''' </summary>
        Public Shared Function GetSelectorList(dtl As List(Of tm_afmeisyoDto), kbn As Enum名称区分) As List(Of DaSelectorModel)
            Select Case kbn
                Case Enum名称区分.名称
                    Return dtl.[Select](Function(d) New DaSelectorModel(d.nmcd, d.nm)).ToList()
                Case Enum名称区分.カナ
                    Return dtl.[Select](Function(d) New DaSelectorModel(d.nmcd, d.kananm)).ToList()
                Case Enum名称区分.略称
                    Return dtl.[Select](Function(d) New DaSelectorModel(d.nmcd, d.shortnm)).ToList()
                Case Else
                    Throw New Exception("Enum名称区分 error")
            End Select
        End Function

        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Shared Function GetCdNm(db As DaDbContext, nmKbn As EnumNmKbn, kbn As Enum名称区分, cd As String) As String
            Return DaSelectorService.GetCdNm(db, cd, kbn, Enumマスタ区分.名称マスタ, CLng(nmKbn).ToString())
        End Function

        ''' <summary>
        ''' 名称取得
        ''' </summary>
        Public Shared Function GetName(db As DaDbContext, nmKbn As EnumNmKbn, cd As String) As String
            'Return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, CLng(nmKbn).ToString())
            Return String.Empty

        End Function

        ''' <summary>
        ''' カナ名称取得
        ''' </summary>
        'Public Shared Function GetKanaName(db As DaDbContext, nmKbn As EnumNmKbn, cd As String) As String
        '    Return DaSelectorService.GetName(db, cd, Enum名称区分.カナ, Enumマスタ区分.名称マスタ, CLng(nmKbn).ToString())
        'End Function

        '''' <summary>
        '''' 略称取得
        '''' </summary>
        'Public Shared Function GetShortName(db As DaDbContext, nmKbn As EnumNmKbn, cd As String) As String
        '    Return DaSelectorService.GetName(db, cd, Enum名称区分.略称, Enumマスタ区分.名称マスタ, CLng(nmKbn).ToString())
        'End Function

        ''' <summary>
        ''' 汎用区分1取得
        ''' </summary>
        'Public Shared Function GetKbn1(db As DaDbContext, nmKbn As EnumNmKbn, nmCd As String) As String
        '    Dim list = GetNameList(db, nmKbn)
        '    Dim row = list.Find(Function(x) Equals(x.nmcd, nmCd))
        '    If row Is Nothing Then Return String.Empty
        '    Return If(Not Equals(row.hanyokbn1, Nothing), row.hanyokbn1, String.Empty)
        'End Function

        ''' <summary>
        ''' 汎用区分1取得
        ''' </summary>
        'Public Shared Function GetKbn1(db As DaDbContext, maincd As String, subcd As Integer, nmCd As String) As String
        '    Dim list = GetNameList(db, maincd, subcd)
        '    Dim row = list.Find(Function(x) Equals(x.nmcd, nmCd))
        '    If row Is Nothing Then Return String.Empty
        '    Return If(Not Equals(row.hanyokbn1, Nothing), row.hanyokbn1, String.Empty)
        'End Function

        ''' <summary>
        ''' 汎用区分2取得
        ''' </summary>
        'Public Shared Function GetKbn2(db As DaDbContext, nmKbn As EnumNmKbn, nmCd As String) As String
        '    Dim list = GetNameList(db, nmKbn)
        '    Dim row = list.Find(Function(x) Equals(x.nmcd, nmCd))
        '    If row Is Nothing Then Return String.Empty
        '    Return If(Not Equals(row.hanyokbn2, Nothing), row.hanyokbn2, String.Empty)
        'End Function
        ''' <summary>
        ''' 汎用区分3取得
        ''' </summary>
        'Public Shared Function GetKbn3(db As DaDbContext, nmKbn As EnumNmKbn, nmCd As String) As String
        '    Dim list = GetNameList(db, nmKbn)
        '    Dim row = list.Find(Function(x) Equals(x.nmcd, nmCd))
        '    If row Is Nothing Then Return String.Empty
        '    Return If(Not Equals(row.hanyokbn3, Nothing), row.hanyokbn3, String.Empty)
        'End Function

        ''' <summary>
        ''' 備考取得
        ''' </summary>
        'Public Shared Function GetBiko(db As DaDbContext, nmKbn As EnumNmKbn, nmCd As String) As String
        '    Dim list = GetNameList(db, nmKbn)
        '    Dim row = list.Find(Function(x) Equals(x.nmcd, nmCd))
        '    If row Is Nothing Then Return String.Empty
        '    Return If(Not Equals(row.biko, Nothing), row.biko, String.Empty)
        'End Function

        ''' <summary>
        ''' 名称リスト取得
        ''' </summary>
        'Public Shared Function GetNameList(db As DaDbContext, nmKbn As EnumNmKbn) As List(Of tm_afmeisyoDto)
        '    Dim maincd As String = (CLng(nmKbn) / MAINCODE_DIGIT).ToString()
        '    Dim subcd As Integer = nmKbn Mod MAINCODE_DIGIT
        '    Return GetNameList(db, maincd, subcd)
        'End Function

        '''' <summary>
        '''' 名称区分取得
        '''' </summary>
        'Public Shared Function GetNmKbn(maincd As String, subcd As Integer) As EnumNmKbn
        '    Return DaConvertUtil.CInt(maincd) * MAINCODE_DIGIT + subcd
        'End Function

        ''' <summary>
        ''' 名称一覧の取得
        ''' </summary>
'        Private Shared Function GetNameList(db As DaDbContext, maincd As String, subcd As Integer) As List(Of tm_afmeisyoDto)
'            If _cache Is Nothing Then
'                _cache = New MemoryCache(New MemoryCacheOptions())
'            End If

'            Dim key = $"{maincd}-{subcd}"
'            'data = db.Session.Query<tm_afmeisyoDto>(sql);
'            Dim data As List(Of tm_afmeisyoDto)
'                        ''' Cannot convert IfStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
''''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitIfStatement(IfStatementSyntax node)
''''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
''''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
'''' 
'''' Input:
''''             if (!JBD.GJS.Db.DaNameService._cache.TryGetValue(key, out data!))
''''             {
''''                 string sql = $"SELECT * FROM {JBD.GJS.Db.tm_afmeisyoDto.TABLE_NAME} " +
''''                     $"WHERE {nameof(JBD.GJS.Db.tm_afmeisyoDto.nmmaincd)}='{maincd}' AND {nameof(JBD.GJS.Db.tm_afmeisyoDto.nmsubcd)}={subcd} " +
''''                     $"ORDER BY {nameof(JBD.GJS.Db.tm_afmeisyoDto.nmmaincd)}, {nameof(JBD.GJS.Db.tm_afmeisyoDto.nmsubcd)}";
''''                 //data = db.Session.Query<tm_afmeisyoDto>(sql);
''''                 JBD.GJS.Db.DaNameService._cache.Set(key, data, System.TimeSpan.FromMinutes(JBD.GJS.Db.DaNameService.CACHE_MINIUTE));
''''             }
'''' 
'''' 
'            Return data
'        End Function
    End Class
End Namespace
