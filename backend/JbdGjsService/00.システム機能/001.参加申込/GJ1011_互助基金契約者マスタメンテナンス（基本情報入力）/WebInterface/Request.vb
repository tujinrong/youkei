' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（基本情報入力）
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1011

    ''' <summary>
    ''' 初期化処理_詳細画面
    ''' </summary>
    Public Class InitDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 金融機関コード
        ''' </summary>
        Public Property FURI_BANK_CD As String = String.Empty

    End Class

    ''' <summary>
    ''' 検索処理_詳細画面
    ''' </summary>
    Public Class SearchDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 契約者情報
        ''' </summary>
        Public Property KEIYAKUSYA As DetailVM = New DetailVM

    End Class

    ''' <summary>
    ''' 削除処理_詳細画面処理
    ''' </summary>
    Public Class DeleteRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先番号(変更前)
        ''' </summary>
        Public Property OLD_JIMUITAKU_CD As Integer? = Nothing

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
