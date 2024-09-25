' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（基本情報入力）
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1011

    ''' <summary>
    ''' 金融機関情報
    ''' </summary>
    Public Class DetailVM
        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing
        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing
        ''' <summary>
        ''' 経営安定対策事業生産者番号
        ''' </summary>
        Public Property SEISANSYA_CD As Integer? = Nothing
        ''' <summary>
        ''' 都道府県コード
        ''' </summary>
        Public Property KEN_CD As Integer? = Nothing
        ''' <summary>
        ''' 日鶏協番号
        ''' </summary>
        Public Property NIKKEIKYO_CD As Integer? = Nothing
        ''' <summary>
        ''' 契約区分
        ''' </summary>
        Public Property KEIYAKU_KBN As Integer? = Nothing

        ''' <summary>
        ''' 契約日
        ''' </summary>
        Public Property KEIYAKU_DATE As DateTime?
        ''' <summary>
        ''' 契約状況
        ''' </summary>
        Public Property KEIYAKU_JYOKYO As Integer? = Nothing

        ''' <summary>
        ''' 入金日、返還日
        ''' </summary>
        Public Property NYU_HEN_DATE As DateTime?
        ''' <summary>
        ''' 申込者名(ﾌﾘｶﾞﾅ)
        ''' </summary>
        Public Property KEIYAKUSYA_KANA As String = String.Empty
        ''' <summary>
        ''' 申込者名(個人・団体)
        ''' </summary>
        Public Property KEIYAKUSYA_NAME As String = String.Empty
        ''' <summary>
        ''' 代表者名(団体)
        ''' </summary>
        Public Property DAIHYO_NAME As String = String.Empty
        ''' <summary>
        ''' 住所(郵便番号)
        ''' </summary>
        Public Property ADDR_POST As String = String.Empty
        ''' <summary>
        ''' 住所(住所1)
        ''' </summary>
        Public Property ADDR_1 As String = String.Empty
        ''' <summary>
        ''' 住所(住所2)
        ''' </summary>
        Public Property ADDR_2 As String = String.Empty
        ''' <summary>
        ''' 住所(住所3)
        ''' </summary>
        Public Property ADDR_3 As String = String.Empty
        ''' <summary>
        ''' 住所(住所4)
        ''' </summary>
        Public Property ADDR_4 As String = String.Empty
        ''' <summary>
        ''' 連絡先(電話)
        ''' </summary>
        Public Property ADDR_TEL1 As String = String.Empty
        ''' <summary>
        ''' 連絡先(電話2)
        ''' </summary>
        Public Property ADDR_TEL2 As String = String.Empty
        ''' <summary>
        ''' 連絡先(FAX)
        ''' </summary>
        Public Property ADDR_FAX As String = String.Empty
        ''' <summary>
        ''' メールアドレス
        ''' </summary>
        Public Property ADDR_E_MAIL As String = String.Empty
        ''' <summary>
        ''' 事務委託先番号(変更前)
        ''' </summary>
        Public Property OLD_JIMUITAKU_CD As Integer? = Nothing
        ''' <summary>
        ''' 事務委託先番号
        ''' </summary>
        Public Property JIMUITAKU_CD As Integer? = Nothing
        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property FURI_BANK_CD As String = String.Empty
        ''' <summary>
        ''' 本支店コード
        ''' </summary>
        Public Property FURI_BANK_SITEN_CD As String = String.Empty
        ''' <summary>
        ''' 口座種別コード
        ''' </summary>
        Public Property FURI_KOZA_SYUBETU As Integer? = Nothing
        ''' <summary>
        ''' 口座番号
        ''' </summary>
        Public Property FURI_KOZA_NO As String = String.Empty
        ''' <summary>
        ''' 口座名義人(カナ)
        ''' </summary>
        Public Property FURI_KOZA_MEIGI_KANA As String = String.Empty
        ''' <summary>
        ''' 口座名義人(漢字)
        ''' </summary>
        Public Property FURI_KOZA_MEIGI As String = String.Empty
        ''' <summary>
        ''' 入力確認有無
        ''' </summary>
        Public Property NYURYOKU_JYOKYO As Integer? = Nothing
        ''' <summary>
        ''' 備考
        ''' </summary>
        Public Property BIKO As String = String.Empty
        ''' <summary>
        ''' 廃業日
        ''' </summary>
        Public Property HAIGYO_DATE As DateTime?
        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
