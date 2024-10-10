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
                '期
                If row("KI") Is DBNull.Value Then
                    item.SYORI_KI.KI = Nothing
                Else
                    item.SYORI_KI.KI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("KI")))
                End If
                '事業対象開始年度
                If row("JIGYO_NENDO") Is DBNull.Value Then
                    item.SYORI_KI.JIGYO_NENDO = Nothing
                Else
                    item.SYORI_KI.JIGYO_NENDO = DaConvertUtil.CInt(row("JIGYO_NENDO"))
                End If
                '事業対象終了年度
                If row("JIGYO_SYURYO_NENDO") Is DBNull.Value Then
                    item.SYORI_KI.JIGYO_SYURYO_NENDO = Nothing
                Else
                    item.SYORI_KI.JIGYO_SYURYO_NENDO = DaConvertUtil.CInt(row("JIGYO_SYURYO_NENDO"))
                End If

                '前期積立金取込日
                If row("ZENKI_TUMITATE_DATE") Is DBNull.Value Then 
                    item.SYORI_KI.ZENKI_TUMITATE_DATE = Nothing
                Else
                    item.SYORI_KI.ZENKI_TUMITATE_DATE = DaConvertUtil.CNDate(row("ZENKI_TUMITATE_DATE"))
                End If

                '前期交付金取込日
                If row("ZENKI_KOFU_DATE") Is DBNull.Value Then 
                    item.SYORI_KI.ZENKI_KOFU_DATE = Nothing
                Else
                    item.SYORI_KI.ZENKI_KOFU_DATE = DaConvertUtil.CNDate(row("ZENKI_KOFU_DATE"))
                End If

                '返還金計算日
                If row("HENKAN_KEISAN_DATE") Is DBNull.Value Then 
                    item.SYORI_KI.HENKAN_KEISAN_DATE = Nothing
                Else
                    item.SYORI_KI.HENKAN_KEISAN_DATE = DaConvertUtil.CNDate( row("HENKAN_KEISAN_DATE"))
                End If
                
                '積立金返還人数
                item.SYORI_KI.HENKAN_NINZU = DaConvertUtil.CInt(row("HENKAN_NINZU"))
                '積立金返還額合計
                item.SYORI_KI.HENKAN_GOKEI = DaConvertUtil.CInt(row("HENKAN_GOKEI"))
                '前期積立金返還率
                item.SYORI_KI.HENKAN_RITU = DaConvertUtil.CNDec(row("HENKAN_RITU"))

                '対象年度
                If row("TAISYO_NENDO") Is DBNull.Value Then
                    item.SYORI_KI.TAISYO_NENDO = Nothing
                Else
                    item.SYORI_KI.TAISYO_NENDO = DaConvertUtil.CInt(row("TAISYO_NENDO"))
                End If
                '当初対象積立金納付期限
                If row("NOFU_KIGEN") Is DBNull.Value Then
                    item.SYORI_KI.NOFU_KIGEN = Nothing
                Else
                    item.SYORI_KI.NOFU_KIGEN = DaConvertUtil.CNDate(DaConvertUtil.CNStr(WordHenkan("N", "S", row("NOFU_KIGEN"))))
                End If
                '現在の発生回数
                If row("HASSEI_KAISU") Is DBNull.Value Then
                    item.SYORI_KI.HASSEI_KAISU = Nothing
                Else
                    item.SYORI_KI.HASSEI_KAISU = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASSEI_KAISU")))
                End If
                '備考
                item.SYORI_KI.BIKO = DaConvertUtil.CStr(WordHenkan("N", "S", row("BIKO")))
                item.SYORI_KI.UP_DATE = DaConvertUtil.CNDate(row("UP_DATE"))
                Return item
            Else
                Return New InitDetailResponse("該当デ一タが存在しませんでした。")
            End If
        End Function
    End Class
End Namespace
