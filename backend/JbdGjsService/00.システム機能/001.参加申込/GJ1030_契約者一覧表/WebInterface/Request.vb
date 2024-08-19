' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者一覧表
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

    ''' <summary>
    ''' 初期化処理_プレビュー画面処理
    ''' </summary>
    Public Class InitRequest
        Inherits Db.DaRequestBase

        ''' <summary>
        ''' 対象期
        ''' </summary>
        Public Property KI As Integer = Nothing

    End Class

    ''' <summary>
    ''' プレビュー処理_プレビュー画面処理
    ''' </summary>
    Public Class PreviewRequest
        Inherits Db.DaRequestBase

        ''' <summary>
        ''' 対象期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 対象日(現在)
        ''' </summary>
        Public Property TAISYOBI_YMD As DateTime

        ''' <summary>
        ''' 契約区分コードFROM
        ''' </summary>
        Public Property KEIYAKU_KBN_CD_FM As Integer? = Nothing

        ''' <summary>
        ''' 契約区分コードTO
        ''' </summary>
        Public Property KEIYAKU_KBN_CD_TO As Integer? = Nothing

        ''' <summary>
        ''' 契約状況[新規契約者]
        ''' </summary>
        Public Property KEIYAKU_JYOKYO_SHINKI As Boolean= False

        ''' <summary>
        ''' 契約状況[継続契約者]
        ''' </summary>
        Public Property KEIYAKU_JYOKYO_KEIZOKU As Boolean= False

        ''' <summary>
        ''' 契約状況[中止契約者]
        ''' </summary>
        Public Property KEIYAKU_JYOKYO_CHUSHI As Boolean= False

        ''' <summary>
        ''' 契約状況[廃業者]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        ''' </summary>
        Public Property KEIYAKU_JYOKYO_HAIGYO As Boolean= False

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr? = EnumAndOr.AndCode

    End Class
End Namespace
