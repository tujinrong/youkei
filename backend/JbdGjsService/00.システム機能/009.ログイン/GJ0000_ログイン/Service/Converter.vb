' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ログイン
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000

    ''' <summary>
    ''' ログイン
    ''' </summary>
    Public Class Converter
        Inherits CmConerterBase
        ''' <summary>
        ''' ログイン
        ''' </summary>
        Public Shared Function GetDto(req As LoginRequest) As DataTable
            Dim dt As DataTable = New DataTable
            dt.Columns.Add("USER_ID", GetType(String))
            dt.Columns.Add("PASS", GetType(String))
            Dim dr As DataRow = dt.NewRow()
            dr("USER_ID") = req.USER_ID        'ユーザーID
            dr("PASS") = req.PASS              'パスワード
            dt.Rows.Add(dr)                                
            Return dt
        End Function

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

