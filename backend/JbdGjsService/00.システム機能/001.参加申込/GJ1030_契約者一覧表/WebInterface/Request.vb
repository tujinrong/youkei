' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約者一覧表
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

    ''' <summary>
    ''' 初期化処理_プレビュー画面処理
    ''' </summary>
    Public Class InitRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 対象期
        ''' </summary>
        Public Property KI As Integer = Nothing

    End Class

    ''' <summary>
    ''' プレビュー処理_プレビュー画面処理
    ''' </summary>
    Public Class PreviewRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 対象期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 対象日(現在)
        ''' </summary>
        Public Property TAISYOBI_YMD As DateTime?

        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        Public Property KEIYAKU_KBN_CD As CmCodeFmToModel

        ''' <summary>
        ''' 事務委託先番号コード
        ''' </summary>
        Public Property ITAKU_CD As CmCodeFmToModel

        ''' <summary>
        ''' 契約者番号コード
        ''' </summary>
        Public Property KEIYAKUSYA_CD As CmCodeFmToModel

        ''' <summary>
        ''' 契約状況
        ''' </summary>
        Public Property KEIYAKU_JYOKYO As KeiyakuJyokyo

    End Class
End Namespace
