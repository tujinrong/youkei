' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: メッセージコントロールマスタ
'
' 作成日　　: 2024.07.28
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Module DaMsgControlService
        Private Const CacheMinutes As Double = 3R
                ''' Cannot convert FieldDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''         private static readonly object LockObj = new();
''' 
''' 
                ''' Cannot convert FieldDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''         private static System.Collections.Generic.Dictionary<string, JBD.GJS.Db.tm_afmsgctrlDto> _dic = new();
''' 
''' 
        Private _lastTime As Date

        Public Function GetMsgDto(db As DaDbContext, ctrlmsgid As String) As tm_afmsgctrlDto
            Dim dto As tm_afmsgctrlDto = Nothing
            'SyncLock DaMsgControlService.LockObj
            '    InitCache(db)
            '    Return If(DaMsgControlService._dic.TryGetValue(ctrlmsgid, dto), dto, New tm_afmsgctrlDto())
            'End SyncLock
        End Function

        Private Sub InitCache(db As DaDbContext)
            If DaUtil.Now.Subtract(_lastTime).TotalMinutes < CacheMinutes Then Return
            '_dic = db.tm_afmsgctrl.SELECT.GetDtoList().ToDictionary(x => x.ctrlmsgid, x => x);
            _lastTime = DaUtil.Now
        End Sub

        Public Function GetNotOkResponse(Of TRes As {DaResponseBase, New})(db As DaDbContext, ctrlmsgid As String, ParamArray param As Object()) As TRes
            Dim res = New TRes()
            'メッセージ切替区分を取得
            Dim msgDto = GetMsgDto(db, ctrlmsgid)

            Select Case msgDto.msgkbn
                'エラーの場合
                Case EnumMsgCtrlKbn.エラー
                    res.SetServiceError(DaMessageService.GetMsg(msgDto.errormsgid, param))
                'アラートの場合
                Case EnumMsgCtrlKbn.アラート
                    '非表示の場合
                    res.SetServiceAlert(DaMessageService.GetMsg(msgDto.alertmsgid, param))
                Case Else
                    res.SetServiceHidden()
            End Select
            Return res
        End Function
    End Module
End Namespace
