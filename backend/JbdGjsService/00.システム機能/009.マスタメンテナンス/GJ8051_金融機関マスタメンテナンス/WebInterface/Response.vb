' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8051

    ''' <summary>
    ''' 初期化処理_金融機関詳細画面処理(成功)
    ''' </summary>
    Public Class InitBankDetailResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 金融機関情報
        ''' </summary>
        Public Property BANK As BankDetailVM = New BankDetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
