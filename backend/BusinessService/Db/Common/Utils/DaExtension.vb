' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DataRow拡機能
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices

Namespace JBD.GJS.Db
    '    Public Module DaExtension
    '        ''' <summary>
    '        ''' 画面表示にラッピング処理
    '        ''' </summary>
    '        <Extension()>
    '        Public Function Wrap(Me dr As Data.DataRow, name As String) As String
    '                        ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
    ''''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
    ''''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    ''''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
    ''''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
    '''' 
    '''' Input:
    ''''             var obj = dr[name]!;
    '''' 
    '''' 
    '            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return String.Empty
    '            If TypeOf obj Is Date Then
    '                                ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: 型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' のオブジェクトを型 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax' にキャストできません。
    ''''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
    ''''    場所 ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    ''''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
    ''''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
    '''' 
    '''' Input:
    ''''                 var column = dr.Table.Columns[name]!;
    '''' 
    '''' 
    '                Dim columnName As String = column.ColumnName
    '                Return DaExtension.FormatDate(CDate(obj), columnName)
    '            Else
    '                Return
    '            End If
    '        End Function

    '        ''' <summary>
    '        ''' 画面表示にラッピング処理
    '        ''' </summary>
    '        <Extension()>
    '        Public Function Wrap(Me dr As Data.DataRow, name1 As String, name2 As String) As String
    '            Dim obj = dr(name1)
    '            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return String.Empty
    '            Return Conversions.ToString(dr(name1)) & " " & Conversions.ToString(dr(name2))
    '        End Function

    '        ''' <summary>
    '        ''' 日付編集
    '        ''' </summary>
    '        Private Function FormatDate(value As Date, name As String) As String
    '            If name.Contains("日時") Then
    '                Return value.ToString(DaConst.JapanTimeFormat)
    '            Else
    '                Return value.ToString(DaConst.JapanDateFormat)
    '            End If
    '        End Function

    '        <Extension()>
    '        Public Function ToNStr(Me dr As Data.DataRow, name As String) As String
    '            Dim obj = dr(name)
    '            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return Nothing
    '            Return dr.Wrap(name)
    '        End Function

    '        ''' <summary>
    '        ''' 日付編集
    '        ''' </summary>
    '        'public static string FormatDate(this DataRow dr, string name, string fmt)
    '        '{
    '        '    var obj = dr[name];
    '        '    if (obj is null || obj is DBNull) return string.Empty;
    '        '    return AiDataUtil.FormatDate((DateTime)obj, fmt);
    '        '}

    '        ''' <summary>
    '        ''' 日付編集
    '        ''' </summary>
    '        <Extension()>
    '        Public Function FormatKjYM(Me dr As Data.DataRow, name As String) As String
    '            Dim obj = dr(name)
    '            If obj Is Nothing OrElse TypeOf obj Is DBNull Then Return String.Empty
    '            Return
    '        End Function
    '        <Extension()>
    '        Public Function [CStr](Me dr As Data.DataRow, name As String) As String
    '            Return DaConvertUtil.CStr(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function [CInt](Me dr As Data.DataRow, name As String) As Integer
    '            Return DaConvertUtil.CInt(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function CNInt(Me dr As Data.DataRow, name As String) As Integer
    '            Return DaConvertUtil.CNInt(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function [CLng](Me dr As Data.DataRow, name As String) As Long
    '            Return DaConvertUtil.CLng(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function CNLng(Me dr As Data.DataRow, name As String) As Long
    '            Return DaConvertUtil.CNLng(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function [CDec](Me dr As Data.DataRow, name As String) As Decimal
    '            Return DaConvertUtil.CDec(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function CNDec(Me dr As Data.DataRow, name As String) As Decimal
    '            Return DaConvertUtil.CNDec(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function [CDate](Me dr As Data.DataRow, name As String) As Date
    '            Return DaConvertUtil.CDate(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function CNDate(Me dr As Data.DataRow, name As String) As Date
    '            Return DaConvertUtil.CNDate(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function [CBool](Me dr As Data.DataRow, name As String) As Boolean
    '            Return DaConvertUtil.CBool(dr(name))
    '        End Function
    '        <Extension()>
    '        Public Function CNBool(Me dr As Data.DataRow, name As String) As Boolean
    '            Return DaConvertUtil.CNBool(dr(name))
    '        End Function
    '    End Module
End Namespace
