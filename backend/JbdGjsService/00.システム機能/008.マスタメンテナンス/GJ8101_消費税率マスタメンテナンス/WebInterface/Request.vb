' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 消費税率マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8101

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class InitDetailRequest
        Inherits DaRequestBase
        
        ''' <summary>
        ''' 適用開始日
        ''' </summary>
        Public Property TAX_DATE_FROM As DateTime? = Nothing

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 消費税率情報
        ''' </summary>
        Public Property TAX As DetailVM = New DetailVM

    End Class

    ''' <summary>
    ''' 削除処理_詳細画面処理
    ''' </summary>
    Public Class DeleteRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 適用開始日
        ''' </summary>
        Public Property TAX_DATE_FROM As Integer? = Nothing

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
