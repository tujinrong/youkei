' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先一覧表
'            ビューモデル定義
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8060

   ''' <summary>
    ''' 検索条件入力情報
    ''' </summary>
    Public Class SearchVM

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 都道府県
        ''' </summary>
        Public Property KEN_CD As CmCodeFmToModel

        ''' <summary>
        ''' 事務委託先名
        ''' </summary>
        Public Property ITAKU_NAME As String = String.Empty

        ''' <summary>
        ''' 事務委託先
        ''' </summary>
        Public Property ITAKU_CD As Integer? = Nothing

        ''' <summary>
        ''' まとめ先
        ''' </summary>
        Public Property MATOMESAKI As Integer? = Nothing

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr

    End Class

    ''' <summary>
    ''' 使用者情報
    ''' </summary>
    Public Class SearchRowVM

        ''' <summary>
        ''' 事務委託先
        ''' </summary>
        Public Property ITAKU_CD As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先名
        ''' </summary>
        Public Property ITAKU_NAME As String = String.Empty

        ''' <summary>
        ''' 電話番号
        ''' </summary>
        Public Property ADDR_TEL As String = String.Empty

        ''' <summary>
        ''' 郵便番号
        ''' </summary>
        Public Property ADDR_POST As String = String.Empty

        ''' <summary>
        ''' 住所
        ''' </summary>
        Public Property ADDR As String = String.Empty

    End Class
End Namespace
