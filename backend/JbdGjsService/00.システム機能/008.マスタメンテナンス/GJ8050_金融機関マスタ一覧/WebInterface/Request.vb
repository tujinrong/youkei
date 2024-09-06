' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタ一覧
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8050

    ''' <summary>
    ''' 検索処理_金融機関一覧画面処理
    ''' </summary>
    Public Class SearchBankRequest
        Inherits CmSearchRequestBase

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

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr = EnumAndOr.AndCode
    End Class

    ''' <summary>
    ''' 検索処理_支店一覧画面処理
    ''' </summary>
    Public Class SearchSitenRequest
        Inherits CmSearchRequestBase

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

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr = EnumAndOr.AndCode
    End Class

    ''' <summary>
    ''' プレビュー処理_金融機関プレビュー画面処理
    ''' </summary>
    Public Class PreviewBankRequest
        Inherits CmSearchRequestBase

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

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr = EnumAndOr.AndCode
    End Class

    ''' <summary>
    ''' プレビュー処理_支店プレビュー画面処理
    ''' </summary>
    Public Class PreviewSitenRequest
        Inherits CmSearchRequestBase

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

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr = EnumAndOr.AndCode
    End Class
End Namespace
