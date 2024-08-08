' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ビジネスサービスインスタンス管理
'
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    Public Class ServiceFactory
        ''' Cannot convert FieldDeclarationSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        '''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
        '''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node)
        '''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        '''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        ''' 
        ''' Input:
        Private _businessServices As New Dictionary(Of String, Object)()
 
        Public Function GetService(ByVal svcName As String) As Object
            Dim serviceFullName = If(svcName.StartsWith("Common."), $"JbdGjsService.JBD.GJS.Service.{svcName}", $"JbdGjsService.JBD.GJS.Service.{svcName}.Service")

            Dim service As Object = Nothing

            If Me._businessServices.TryGetValue(serviceFullName, service) Then
                Return service
            End If
            Return New Object()

        End Function

        Public Sub AddService(ByVal name As String, ByVal serviceObj As Object)

            If Me._businessServices.ContainsKey(name) Then
                Throw New InvalidOperationException($"「{name}」という名前のサービスはすでに存在します。")
            End If

            Me._businessServices.Add(name, serviceObj)
        End Sub
    End Class
End Namespace
