' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタ一覧
'            ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1010

    ''' <summary>
    ''' 契約者情報
    ''' </summary>
    Public Class SearchRowVM

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer = Nothing

        ''' <summary>
        ''' 契約者名
        ''' </summary>
        Public Property KEIYAKUSYA_NAME As String = String.Empty

        ''' <summary>
        ''' フリガナ
        ''' </summary>
        Public Property KEIYAKUSYA_KANA As String = String.Empty

        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        Public Property KEIYAKU_KBN As Integer = Nothing

        ''' <summary>
        ''' 契約区分名
        ''' </summary>
        Public Property KEIYAKU_KBN_NAME As String = String.Empty

        ''' <summary>
        ''' 契約状況
        ''' </summary>
        Public Property KEIYAKU_JYOKYO As String = String.Empty

        ''' <summary>
        ''' 電話番号
        ''' </summary>
        Public Property ADDR_TEL1 As String = String.Empty

        ''' <summary>
        ''' 都道府県
        ''' </summary>
        Public Property KEN_CD_NAME As String = String.Empty

        ''' <summary>
        ''' 事務委託先略称
        ''' </summary>
        Public Property ITAKU_RYAKU As String = String.Empty

    End Class
End Namespace
