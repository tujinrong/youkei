' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8091

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class SearchDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer = Nothing

        ''' <summary>
        ''' 農場番号
        ''' </summary>
        Public Property NOJO_CD As Integer = Nothing

    End Class

    ''' <summary>
    ''' 削除処理_詳細画面処理
    ''' </summary>
    Public Class DeleteRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer = Nothing

        ''' <summary>
        ''' 農場番号
        ''' </summary>
        Public Property NOJO_CD As Integer = Nothing

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 契約者農場情報
        ''' </summary>
        Public Property KEIYAKUSYA_NOJO As DetailVM = New DetailVM

        Public Property EDIT_KBN As Enum編集区分 = Enum編集区分.新規
        

    End Class
End Namespace
