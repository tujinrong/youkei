' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8061

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class InitDetailRequest
        Inherits DaRequestBase
        
        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先番号
        ''' </summary>
        Public Property ITAKU_CD As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 事務委託先情報
        ''' </summary>
        Public Property ITAKU As DetailVM = New DetailVM

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
        ''' 事務委託先番号
        ''' </summary>
        Public Property ITAKU_CD As Integer? = Nothing

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
