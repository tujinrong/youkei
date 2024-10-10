' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8051

    ''' <summary>
    ''' 金融機関情報
    ''' </summary>
    Public Class BankDetailVM

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
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
