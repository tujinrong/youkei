' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタ一覧
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Imports OracleInternal

Namespace JBD.GJS.Service.GJ1010

    ''' <summary>
    ''' 互助基金契約者マスタ一覧
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_一覧画面
        ''' </summary>
        Public Shared Function GetInitResponse(ByVal wKbn As String, req As InitRequest, dt1 As DataTable, dt2 As DataTable, dt3 As DataTable) As InitResponse
            Dim res = New InitResponse()
            Dim sWhere As String = String.Empty
            res.KEN_LIST = New List(Of CmCodeNameModel)
            res.KEIYAKU_KBN_LIST = New List(Of CmCodeNameModel)
            res.KEIYAKU_JYOKYO_LIST = New List(Of CmCodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt1.Rows
                Dim item As New CmCodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.KEN_LIST.Add(item)
            Next
            For Each row As DataRow In dt2.Rows
                Dim item As New CmCodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.KEIYAKU_KBN_LIST.Add(item)
            Next
            For Each row As DataRow In dt3.Rows
                Dim item As New CmCodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.KEIYAKU_JYOKYO_LIST.Add(item)
            Next
            If wKbn = "C" Then
                sWhere = "KI = " & req.KI
                Dim jdt = f_JimuItaku_Data_Select(sWhere)
                'データ結果判定
                If jdt.Rows.Count > 0 Then
                    res.ITAKU_LIST = New List(Of CmCodeNameModel)
                    ' dt をループし、List にデータを追加します。
                    For Each row As DataRow In jdt.Rows
                        Dim item As New CmCodeNameModel
                        item.CODE = CInt(row("ITAKU_CD").ToString())
                        item.NAME = row("ITAKU_NAME").ToString()
                        res.ITAKU_LIST.Add(item)
                    Next
                End If
            End If
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.TOTAL_ROW_COUNT = CInt(CStr(dt.Rows(0)("RCNT")))
                res.TOTAL_PAGE_COUNT = CInt(CStr(dt.Rows(0)("PCNT")))
                res.KEKKA_LIST = New List(Of SearchRowVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New SearchRowVM
                    item.KEIYAKUSYA_CD = CInt(CStr(row("KEIYAKUSYA_CD")))
                    item.KEIYAKUSYA_NAME = CStr(row("KEIYAKUSYA_NAME"))
                    item.KEIYAKUSYA_KANA = CStr(row("KEIYAKUSYA_KANA"))
                    item.KEIYAKU_KBN = CInt(CStr(row("KEIYAKU_KBN")))
                    item.KEIYAKU_KBN_NAME = CStr(row("KEIYAKU_KBN_NM"))
                    item.KEIYAKU_JYOKYO = CStr(row("KEIYAKU_JYOKYO"))
                    item.ADDR_TEL1 = CStr(row("ADDR_TEL1"))
                    item.KEN_CD_NAME = CStr(row("KEN_NM"))
                    item.ITAKU_RYAKU = CStr(row("ITAKU_RYAKU"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function
    End Class
End Namespace
