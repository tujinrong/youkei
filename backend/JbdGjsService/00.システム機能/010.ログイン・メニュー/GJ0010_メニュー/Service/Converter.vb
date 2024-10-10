' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: メニュー
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0010

    ''' <summary>
    ''' メニュー
    ''' </summary>
    Public Class Converter
        Inherits CmConerterBase

        ''' <summary>
        ''' ユーザー情報を取得する
        ''' </summary>
        Public Shared Function GetDtoUser(req As DaRequestBase) As DataTable
            Dim dt As DataTable = New DataTable
            dt.Columns.Add("TOKEN", GetType(String))
            Dim newRow As DataRow = dt.NewRow()
            newRow("TOKEN") = req.token          'トークン
            dt.Rows.Add(newRow)                                
            Return dt
        End Function

    End Class
End Namespace

