' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約者積立金・互助金単価マスタ一覧
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.10.09
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ2010

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
            res.KEKKA_LIST = New List(Of CmDateFmToModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New CmDateFmToModel
                item.VALUE_FM = DaConvertUtil.CDate(row("TAISYO_DATE_FROM"))
                item.VALUE_TO = DaConvertUtil.CDate(row("TAX_DATE_TO"))
                res.KEKKA_LIST.Add(item)
            Next
            Return res
        End Function

    End Class
End Namespace
