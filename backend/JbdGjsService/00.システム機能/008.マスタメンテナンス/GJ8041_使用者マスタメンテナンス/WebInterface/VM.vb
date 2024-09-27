' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8041

    ''' <summary>
    ''' 契約者農場情報
    ''' </summary>
    Public Class DetailVM

        ''' <summary>
        ''' ユーザーID
        ''' </summary>
        Public Property USER_ID As String = String.Empty

        ''' <summary>
        ''' ユーザー名
        ''' </summary>
        Public Property USER_NAME As String = String.Empty

        ''' <summary>
        ''' パスワード
        ''' </summary>
        Public Property PASS As String = String.Empty

        ''' <summary>
        ''' パスワード有効期限
        ''' </summary>
        Public Property PASS_KIGEN_DATE As DateTime?

        ''' <summary>
        ''' パスワード変更日
        ''' </summary>
        Public Property PASS_UP_DATE As DateTime?

        ''' <summary>
        ''' 使用区分
        ''' </summary>
        Public Property SIYO_KBN As Integer? = Nothing

        ''' <summary>
        ''' 使用停止日
        ''' </summary>
        Public Property TEISI_DATE As DateTime?

        ''' <summary>
        ''' 使用停止理由
        ''' </summary>
        Public Property TEISI_RIYU As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
