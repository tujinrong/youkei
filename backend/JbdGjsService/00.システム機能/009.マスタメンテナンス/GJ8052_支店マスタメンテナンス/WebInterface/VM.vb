' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 支店マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8052

    ''' <summary>
    ''' 支店情報
    ''' </summary>
    Public Class SitenDetailVM

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
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
