' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタ一覧
'            ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8050

    ''' <summary>
    ''' 金融機関情報
    ''' </summary>
    Public Class SearchBankRowVM

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property BANK_CD As String = String.Empty

        ''' <summary>
        ''' 金融機関名（ｶﾅ）
        ''' </summary>
        Public Property BANK_KANA As String = String.Empty

        ''' <summary>
        ''' 金融機関名（漢字）
        ''' </summary>
        Public Property BANK_NAME As String = String.Empty

    End Class

    ''' <summary>
    ''' 支店情報
    ''' </summary>
    Public Class SearchSitenRowVM

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property BANK_CD As String = String.Empty

        ''' <summary>
        ''' 支店コード
        ''' </summary>
        Public Property SITEN_CD As String = String.Empty

        ''' <summary>
        ''' 支店名（ｶﾅ）
        ''' </summary>
        Public Property SITEN_KANA As String = String.Empty

        ''' <summary>
        ''' 支店名（漢字）
        ''' </summary>
        Public Property SITEN_NAME As String = String.Empty

    End Class
End Namespace
