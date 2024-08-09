' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8091

    ''' <summary>
    ''' 契約者農場情報
    ''' </summary>
    Public Class DetailVM

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer = Nothing

        '''' <summary>
        '''' 契約者名
        '''' </summary>
        'Public Property KEIYAKUSYA_NAME As String = String.Empty

        ''' <summary>
        ''' 契約者農場
        ''' </summary>
        Public Property NOJO_CD As Integer = Nothing

        ''' <summary>
        ''' 農場名称
        ''' </summary>
        Public Property NOJO_NAME As String = String.Empty

        ''' <summary>
        ''' 都道府県コード
        ''' </summary>
        Public Property KEN_CD As Integer = 5

        ''' <summary>
        ''' 郵便番号
        ''' </summary>
        Public Property ADDR_POST As String = String.Empty

        ''' <summary>
        ''' 住所1
        ''' </summary>
        Public Property ADDR_1 As String = String.Empty

        ''' <summary>
        ''' 住所2
        ''' </summary>
        Public Property ADDR_2 As String = String.Empty

        ''' <summary>
        ''' 住所3
        ''' </summary>
        Public Property ADDR_3 As String = String.Empty

        ''' <summary>
        ''' 住所4
        ''' </summary>
        Public Property ADDR_4 As String = String.Empty

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property MEISAI_NO As Integer

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime?

    End Class
End Namespace
