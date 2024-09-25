' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（契約情報入力）
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1012

    ''' <summary>
    ''' 検索処理_一覧画面処理
    ''' </summary>
    Public Class SearchRequest
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
    ''' 農場住所情報初期化処理_詳細画面処理
    ''' </summary>
    Public Class InitNojoRequest
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
        ''' 農場コード
        ''' </summary>
        Public Property NOJO_CD As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 前期データコピー処理_詳細画面処理
    ''' </summary>
    Public Class CopyRequest
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
        ''' 契約年月日
        ''' </summary>
        Public Property KEIYAKU_DATE As CmDateFmToModel = New CmDateFmToModel

        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        Public Property KEIYAKU_KBN As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 自動採番
        ''' </summary>
        Public Property SEQNO As Integer? = Nothing
        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing
        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing
        ''' <summary>
        ''' 明細番号
        ''' </summary>
        Public Property MEISAI_NO As Integer? = Nothing
        ''' <summary>
        ''' 農場コード
        ''' </summary>
        Public Property NOJO_CD As Integer? = Nothing
        ''' <summary>
        ''' 農場名
        ''' </summary>
        Public Property NOJO_NAME As String = String.Empty
        ''' <summary>
        ''' 農場住所
        ''' </summary>
        Public Property NOJO_ADDR As String = String.Empty
        ''' <summary>
        ''' 住所(郵便番号)
        ''' </summary>
        Public Property ADDR_POST As String = String.Empty
        ''' <summary>
        ''' 住所(住所１)
        ''' </summary>
        Public Property ADDR_1 As String = String.Empty
        ''' <summary>
        ''' 住所(住所2)
        ''' </summary>
        Public Property ADDR_2 As String = String.Empty
        ''' <summary>
        ''' 住所(住所3)
        ''' </summary>
        Public Property ADDR_3 As String = String.Empty
        ''' <summary>
        ''' 住所(住所4)
        ''' </summary>
        Public Property ADDR_4 As String = String.Empty
        ''' <summary>
        ''' 鳥の種類コード
        ''' </summary>
        Public Property TORI_KBN As Integer? = Nothing
        ''' <summary>
        ''' 鳥の種類名
        ''' </summary>
        Public Property TORI_KBN_NAME As String = String.Empty
        ''' <summary>
        ''' 契約羽数
        ''' </summary>
        Public Property KEIYAKU_HASU As Integer? = Nothing

        ''' <summary>
        ''' 契約年月日
        ''' </summary>
        Public Property KEIYAKU_DATE As CmDateFmToModel = New CmDateFmToModel
        ''' <summary>
        ''' 備考
        ''' </summary>
        Public Property BIKO As String = String.Empty

        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        Public Property KEIYAKU_KBN As Integer? = Nothing
    End Class

    ''' <summary>
    ''' 削除処理_詳細画面処理
    ''' </summary>
    Public Class DeleteRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 自動採番
        ''' </summary>
        Public Property SEQNO As Integer? = Nothing

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
