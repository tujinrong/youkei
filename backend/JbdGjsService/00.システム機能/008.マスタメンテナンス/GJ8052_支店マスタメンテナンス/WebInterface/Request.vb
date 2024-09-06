' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 支店マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8052

    ''' <summary>
    ''' 初期化処理_支店詳細画面処理
    ''' </summary>
    Public Class InitSitenDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property BANK_CD As String = String.Empty

        ''' <summary>
        ''' 支店コード
        ''' </summary>
        Public Property SITEN_CD As String = String.Empty

    End Class

    ''' <summary>
    ''' 保存処理_支店詳細画面処理
    ''' </summary>
    Public Class SaveSitenRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 支店情報
        ''' </summary>
        Public Property SITEN As SitenDetailVM = New SitenDetailVM

    End Class

    ''' <summary>
    ''' 削除処理_支店詳細画面処理
    ''' </summary>
    Public Class DeleteSitenRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property BANK_CD As String = String.Empty

        ''' <summary>
        ''' 支店コード
        ''' </summary>
        Public Property SITEN_CD As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime

    End Class
End Namespace
