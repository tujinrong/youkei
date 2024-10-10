' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8061

    ''' <summary>
    ''' 事務委託先情報
    ''' </summary>
    Public Class DetailVM

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先
        ''' </summary>
        Public Property ITAKU_CD As Integer? = Nothing

        ''' <summary>
        ''' 都道府県
        ''' </summary>
        Public Property KEN_CD As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先名称(正式)
        ''' </summary>
        Public Property ITAKU_NAME As String = String.Empty

        ''' <summary>
        ''' 事務委託先名称(略称)
        ''' </summary>
        Public Property ITAKU_RYAKU As String = String.Empty

        ''' <summary>
        ''' 代表者氏名
        ''' </summary>
        Public Property DAIHYO_NAME As String = String.Empty

        ''' <summary>
        ''' 担当者氏名
        ''' </summary>
        Public Property TANTO_NAME As String = String.Empty

        ''' <summary>
        ''' 住所（郵便番号）
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
        Public Property ADDR_TEL As String = String.Empty

        ''' <summary>
        ''' 連絡先(FAX）
        ''' </summary>
        Public Property ADDR_FAX As String = String.Empty

        ''' <summary>
        ''' メールアドレス
        ''' </summary>
        Public Property ADDR_E_MAIL As String = String.Empty

        ''' <summary>
        ''' 金融機関情報印字有無
        ''' </summary>
        Public Property BANK_INJI_KBN As Integer? = Nothing

        ''' <summary>
        ''' まとめ先
        ''' </summary>
        Public Property MATOMESAKI As Integer? = Nothing

        ''' <summary>
        ''' まとめ先
        ''' </summary>
        Public Property MOSIKOMISYORUI As String = String.Empty

        ''' <summary>
        ''' 請求書・契約書
        ''' </summary>
        Public Property SEIKYUSYO As String = String.Empty

        ''' <summary>
        ''' 入金方法
        ''' </summary>
        Public Property NYUKINHOHO As String = String.Empty

        ''' <summary>
        ''' ラベル発行
        ''' </summary>
        Public Property LABELHAKKO As Integer? = Nothing

        ''' <summary>
        ''' 除外フラグ
        ''' </summary>
        Public Property JYOGAI_FLG As Integer? = Nothing

        ''' <summary>
        ''' 備考
        ''' </summary>
        Public Property BIKO As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime? = Nothing

    End Class
End Namespace
