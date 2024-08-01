' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Namespace Jbd.Gjs.Service.GJ0000
    Public Class Wraper
        Inherits Common.Wraper
        ''' <summary>
        ''' ユーザー共通
        ''' </summary>
        '        Public Shared Function GetUserInfoVM(dto As tm_afuserDto, syozokuDto As tm_afsyozokuDto) As UserInfoVM
        '            Dim vm = New UserInfoVM()
        '            vm.userid = dto.userid                         'ユーザーID
        '            vm.usernm = dto.usernm                         'ユーザー名
        '            vm.syozokunm = DaConvertUtil.CStr(syozokuDto.syozokunm)     '所属コード
        '            'ユーザー権限設定の場合
        '            If dto.authsetflg Then
        '                '所属権限設定の場合
        '                vm.kanrisyaflg = dto.kanrisyaflg           '管理者フラグ
        '            Else   '管理者フラグ
        '                                ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
        ''''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
        ''''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
        ''''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
        '''' 
        '''' Input:
        ''''                 vm.kanrisyaflg = syozokuDto!.kanrisyaflg
        '''' 
        '            End If
        '            Return vm
        '        End Function
    End Class
End Namespace
