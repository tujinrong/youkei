' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.09.27
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8041

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class InitDetailRequest
        Inherits DaRequestBase
    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 使用者情報
        ''' </summary>
        Public Property USER As DetailVM = New DetailVM

    End Class

    ''' <summary>
    ''' 削除処理_詳細画面処理
    ''' </summary>
    Public Class DeleteRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
