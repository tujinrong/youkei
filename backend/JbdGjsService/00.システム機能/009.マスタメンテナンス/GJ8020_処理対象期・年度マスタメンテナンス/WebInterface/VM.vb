' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8020

    ''' <summary>
    ''' 処理対象期・年度マスタメンテナンス情報
    ''' </summary>
    Public Class DetailVM

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 事業対象開始年度
        ''' </summary>
        Public Property JIGYO_NENDO As Integer? = Nothing

        ''' <summary>
        ''' 事業対象終了年度
        ''' </summary>
        Public Property JIGYO_SYURYO_NENDO As Integer? = Nothing

        ''' <summary>
        ''' 前期積立金取込日
        ''' </summary>
        Public Property ZENKI_TUMITATE_DATE As DateTime?

        ''' <summary>
        ''' 前期交付金取込日
        ''' </summary>
        Public Property ZENKI_KOFU_DATE As DateTime?

        ''' <summary>
        ''' 返還金計算日
        ''' </summary>
        Public Property HENKAN_KEISAN_DATE As DateTime?

        ''' <summary>
        ''' 積立金返還人数
        ''' </summary>
        Public Property HENKAN_NINZU As Integer? = Nothing

        ''' <summary>
        ''' 積立金返還額合計
        ''' </summary>
        Public Property HENKAN_GOKEI As Integer? = Nothing

        ''' <summary>
        ''' 前期積立金返還率
        ''' </summary>
        Public Property HENKAN_RITU As Decimal?

        ''' <summary>
        ''' 対象年度
        ''' </summary>
        Public Property TAISYO_NENDO As Integer? = Nothing

        ''' <summary>
        ''' 当初対象積立金納付期限
        ''' </summary>
        Public Property NOFU_KIGEN As DateTime?

        ''' <summary>
        ''' 現在の認定回数
        ''' </summary>
        Public Property HASSEI_KAISU As Integer?

        ''' <summary>
        ''' 備考
        ''' </summary>
        Public Property BIKO As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
