' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
'            リクエストインターフェース
' 作成日　　: 2024.09.18
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8011

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class InitDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 種類区分コード
        ''' </summary>
        Public Property SYURUI_KBN As Integer? = Nothing

        ''' <summary>
        ''' 名称コード
        ''' </summary>
        Public Property MEISYO_CD As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 削除処理_詳細画面処理
    ''' </summary>
    Public Class DeleteRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 種類区分コード
        ''' </summary>
        Public Property SYURUI_KBN As Integer? = Nothing

        ''' <summary>
        ''' 名称コード
        ''' </summary>
        Public Property MEISYO_CD As Integer? = Nothing

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As Datetime?

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' コード情報
        ''' </summary>
        Public Property CODE As DetailVM = New DetailVM

    End Class
End Namespace
