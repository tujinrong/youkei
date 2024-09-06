' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8051

    ''' <summary>
    ''' 初期化処理_金融機関詳細画面処理
    ''' </summary>
    Public Class InitBankDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property BANK_CD As String = String.Empty

    End Class

    ''' <summary>
    ''' 保存処理_金融機関詳細画面処理
    ''' </summary>
    Public Class SaveBankRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 金融機関情報
        ''' </summary>
        Public Property BANK As BankDetailVM = New BankDetailVM

    End Class

    ''' <summary>
    ''' 削除処理_金融機関詳細画面処理
    ''' </summary>
    Public Class DeleteBankRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property BANK_CD As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime

    End Class
End Namespace
