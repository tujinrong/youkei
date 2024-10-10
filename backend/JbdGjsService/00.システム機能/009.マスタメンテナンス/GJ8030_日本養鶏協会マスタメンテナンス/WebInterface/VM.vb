' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 日本養鶏協会マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8030

    ''' <summary>
    ''' 日本養鶏協会マスタメンテナンス情報
    ''' </summary>
    Public Class DetailVM

        ''' <summary>
        ''' 協会区分
        ''' </summary>
        Public Property KYOKAI_KBN As Integer? = Nothing

        ''' <summary>
        ''' 協会名称
        ''' </summary>
        Public Property KYOKAI_NAME As String = String.Empty

        ''' <summary>
        ''' 支援事業名
        ''' </summary>
        Public Property JIGYO_NAME As String = String.Empty

        ''' <summary>
        ''' 役職名
        ''' </summary>
        Public Property YAKUMEI As String = String.Empty

        ''' <summary>
        ''' 会長名
        ''' </summary>
        Public Property KAICHO_NAME As String = String.Empty

        ''' <summary>
        ''' 予備
        ''' </summary>
        Public Property YOBI1 As String = String.Empty

        ''' <summary>
        ''' 郵便番号
        ''' </summary>
        Public Property POST As String = String.Empty

        ''' <summary>
        ''' 住所1
        ''' </summary>
        Public Property ADDR1 As String = String.Empty

        ''' <summary>
        ''' 住所2
        ''' </summary>
        Public Property ADDR2 As String = String.Empty

        ''' <summary>
        ''' 発行番号・漢字
        ''' </summary>
        Public Property HAKKO_NO_KANJI As String = String.Empty

        ''' <summary>
        ''' 電話1
        ''' </summary>
        Public Property TEL1 As String = String.Empty

        ''' <summary>
        ''' FAX1
        ''' </summary>
        Public Property FAX1 As String = String.Empty

        ''' <summary>
        ''' E-Mail1
        ''' </summary>
        Public Property E_MAIL1 As String = String.Empty

        ''' <summary>
        ''' 電話2
        ''' </summary>
        Public Property TEL2 As String = String.Empty

        ''' <summary>
        ''' FAX2
        ''' </summary>
        Public Property FAX2 As String = String.Empty

        ''' <summary>
        ''' E-Mail2
        ''' </summary>
        Public Property E_MAIL2 As String = String.Empty

        ''' <summary>
        ''' ホームページURL
        ''' </summary>
        Public Property HP_URL As String = String.Empty

        ''' <summary>
        ''' 登録番号
        ''' </summary>
        Public Property TOUROKU_NO As String = String.Empty

        ''' <summary>
        ''' 振込　金融機関
        ''' </summary>
        Public Property FURI_BANK_CD As String = String.Empty

        ''' <summary>
        ''' 振込　本支店
        ''' </summary>
        Public Property FURI_BANK_SITEN_CD As String = String.Empty

        ''' <summary>
        ''' 振込　口座種別
        ''' </summary>
        Public Property FURI_KOZA_SYUBETU As Integer? = Nothing

        ''' <summary>
        ''' 振込　口座番号
        ''' </summary>
        Public Property FURI_KOZA_NO As String = String.Empty

        ''' <summary>
        ''' 振込　種別コード
        ''' </summary>
        Public Property FURI_SYUBETU As Integer? = Nothing

        ''' <summary>
        ''' 振込　口座名義人（カナ）
        ''' </summary>
        Public Property FURI_KOZA_MEIGI_KANA As String = String.Empty

        ''' <summary>
        ''' 振込　口座名義人（漢字）
        ''' </summary>
        Public Property FURI_KOZA_MEIGI As String = String.Empty

        ''' <summary>
        ''' 支払　金融機関
        ''' </summary>
        Public Property KOFU_BANK_CD As String = String.Empty

        ''' <summary>
        ''' 支払　本支店
        ''' </summary>
        Public Property KOFU_BANK_SITEN_CD As String = String.Empty

        ''' <summary>
        ''' 支払　口座種別
        ''' </summary>
        Public Property KOFU_KOZA_SYUBETU As Integer? = Nothing

        ''' <summary>
        ''' 支払　口座番号
        ''' </summary>
        Public Property KOFU_KOZA_NO As String = String.Empty

        ''' <summary>
        ''' 支払　種別コード
        ''' </summary>
        Public Property KOFU_SYUBETU As Integer? = Nothing

        ''' <summary>
        ''' 支払　コード区分
        ''' </summary>
        Public Property KOFU_CD_KBN As Integer? = Nothing

        ''' <summary>
        ''' 支払　依頼人コード
        ''' </summary>
        Public Property KOFU_KAISYA_CD As Long? = Nothing

        ''' <summary>
        ''' 支払　振込依頼人名（ﾌﾘｶﾞﾅ）
        ''' </summary>
        Public Property KOFU_KAISYA_NAME As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
