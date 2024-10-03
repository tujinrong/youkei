' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 消費税率一覧表
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.10.03
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8100

    ''' <summary>
    ''' 事務委託先一覧表
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            'データ結果判定
            res.KEKKA_LIST = New List(Of SearchRowVM)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New SearchRowVM
                item.TAX_DATE_FROM = DaConvertUtil.CDate(row("TAX_DATE_FROM"))
                If Not String.IsNullOrEmpty( row("TAX_DATE_TO").ToString())
                    item.TAX_DATE_TO = DaConvertUtil.CDate(row("TAX_DATE_TO"))
                End If
                If Not String.IsNullOrEmpty( row("TAX_RITU").ToString())
                    item.TAX_RITU = DaConvertUtil.CInt(row("TAX_RITU"))
                End If
                res.KEKKA_LIST.Add(item)
            Next
            Return res
        End Function

    End Class
End Namespace
