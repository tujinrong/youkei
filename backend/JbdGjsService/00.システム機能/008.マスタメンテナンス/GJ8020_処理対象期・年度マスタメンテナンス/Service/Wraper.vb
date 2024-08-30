' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'             DB項目から画面項目に変換
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8020

    ''' <summary>
    ''' 処理対象期・年度マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_一覧画面
        ''' </summary>
        Public Shared Function GetInitDetailResponse(dt As DataTable) As InitDetailResponse
            'データ結果判定
            If dt.Rows.Count > 0 Then
                ' dt をループし、List にデータを追加します。
                Dim row As DataRow = dt.Rows(0)
                Dim item = New InitDetailResponse()
                item.SYORI_KI.KI = CInt(CStr(row("KI")))
                item.SYORI_KI.JIGYO_NENDO = CInt(CStr(row("JIGYO_NENDO")))
                item.SYORI_KI.JIGYO_SYURYO_NENDO = CInt(CStr(row("JIGYO_SYURYO_NENDO")))
                item.SYORI_KI.ZENKI_TUMITATE_DATE = CDate(row("ZENKI_TUMITATE_DATE"))
                item.SYORI_KI.ZENKI_KOFU_DATE = CDate(row("ZENKI_KOFU_DATE"))
                item.SYORI_KI.HENKAN_KEISAN_DATE = CDate(row("HENKAN_KEISAN_DATE"))
                item.SYORI_KI.HENKAN_NINZU = CInt(CStr(row("HENKAN_NINZU")))
                item.SYORI_KI.HENKAN_GOKEI = CInt(CStr(row("HENKAN_GOKEI")))
                item.SYORI_KI.HENKAN_RITU = DaConvertUtil.CNDec(row("HENKAN_RITU"))
                item.SYORI_KI.TAISYO_NENDO = CInt(CStr(row("TAISYO_NENDO")))
                item.SYORI_KI.NOFU_KIGEN = CDate(row("NOFU_KIGEN"))
                item.SYORI_KI.HASSEI_KAISU = CInt(CStr(row("HASSEI_KAISU")))
                item.SYORI_KI.BIKO = CStr(row("BIKO"))
                item.SYORI_KI.UP_DATE = CDate(row("UP_DATE"))
                Return item
            Else
                Return New InitDetailResponse("該当デ一タが存在しませんでした。")
            End If
        End Function
    End Class
End Namespace
