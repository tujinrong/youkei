' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: チェック処理
' 
' 作成日　　: 2024.07.10
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmCheckService
        ''' <summary>
        ''' 存在チェック
        ''' </summary>
        Public Shared Function CheckExist(obj As Object, res As Db.DaResponseBase, msg As String) As Boolean
            If obj Is Nothing Then
                res.SetServiceError(msg)
                Return False
            End If
            Return True
        End Function

        ''' <summary>
        ''' 存在チェック
        ''' </summary>
        Public Shared Function CheckExist(obj As Object, res As Db.DaResponseBase, msgID As Db.EnumMessage, ParamArray param As String()) As Boolean
            If obj Is Nothing Then
                res.SetServiceError(msgID, param)
                Return False
            End If
            Return True
        End Function

        ''' <summary>
        ''' データ存在チェック
        ''' </summary>
        Public Shared Function CheckDeleted(res As Db.DaResponseBase, dto As Object) As Boolean
            Dim msg = Db.DaMessageService.GetMsg(Db.EnumMessage.DATA_NOTEXIST_ERROR, "更新対象", "更新")
            Return CheckDeleted(res, dto, msg)
        End Function

        ''' <summary>
        ''' データ存在チェック
        ''' </summary>
        Public Shared Function CheckDeleted(res As Db.DaResponseBase, dto As Object, msgID As Db.EnumMessage, ParamArray param As String()) As Boolean
            Dim msg = Db.DaMessageService.GetMsg(msgID, param)
            Return CheckDeleted(res, dto, msg)
        End Function

        ''' <summary>
        ''' データ存在チェック
        ''' </summary>
        Public Shared Function CheckDeleted(res As Db.DaResponseBase, dto As Object, msg As String) As Boolean
            If dto Is Nothing Then
                res.SetServiceError(msg)
                Return False
            Else
                Dim infos = dto.GetType().GetProperties().ToList()
                If infos.Exists(Function(x) Equals(x.Name, NameOf(Db.tm_afuserDto.stopflg))) Then
                    ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
                    '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
                    '''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
                    '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
                    '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
                    ''' 
                    ''' Input:
                    '''                     bool stopflg = (bool)(dto.GetType().GetProperty((System.String)(nameof((System.Boolean)(JBD.GJS.Db.tm_afuserDto.stopflg))))!.GetValue(dto)!);
                    ''' 
                    ''' 
                    'If stopflg Then
                    res.SetServiceError(msg)
                        Return False
                    ' End If
                End If
            End If
            Return True
        End Function


    End Class
End Namespace
