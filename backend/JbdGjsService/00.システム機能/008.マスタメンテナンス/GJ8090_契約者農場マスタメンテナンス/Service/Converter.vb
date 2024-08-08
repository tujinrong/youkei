' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

    ''' <summary>
    ''' 初期化処理_一覧画面
    ''' </summary>
    Public Class Converter
        Inherits JBD.GJS.Service.CmConerterBase

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

