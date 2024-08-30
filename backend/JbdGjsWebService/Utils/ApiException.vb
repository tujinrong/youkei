' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 例外処理
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    Public Class WebApiExceptionFilterAttribute
        Inherits ExceptionFilterAttribute
        Public Overrides Sub OnException(ByVal executedContext As ExceptionContext)
            Dim actionExecutedContext = TryCast(executedContext.HttpContext.RequestServices.GetService(GetType(ActionExecutedContext)), ActionExecutedContext)
            'todo 
            Dim logmsg = String.Empty
            ' log記録
            If actionExecutedContext Is Nothing Then
                'logmsg = CSharpImpl.__Assign(logmsg, String.Format("{0}" & Environment.NewLine & "{1}", executedContext.Exception.Message, executedContext.Exception.StackTrace))
                logmsg = string.Format(logmsg, String.Format("{0}" & Environment.NewLine & "{1}", executedContext.Exception.Message, executedContext.Exception.StackTrace))
            Else
                                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
                 logmsg = string.Format("{0}" + System.Environment.NewLine + "{1}", actionExecutedContext.Exception.Message, actionExecutedContext.Exception.StackTrace)
''' 
            End If

            MyBase.OnException(executedContext)
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
