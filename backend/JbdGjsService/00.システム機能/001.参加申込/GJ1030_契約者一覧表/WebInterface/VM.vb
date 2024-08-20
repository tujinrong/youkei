' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者一覧表
'            ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

    ''' <summary>
    ''' 契約者農場情報
    ''' </summary>
    Public Class KeiyakuNojo

        ''' <summary>
        ''' 農場コード
        ''' </summary>
        Public Property NOJO_CD As Integer = Nothing

        ''' <summary>
        ''' 農場名
        ''' </summary>
        Public Property NOJO_NAME As String = String.Empty

        ''' <summary>
        ''' 住所
        ''' </summary>
        Public Property ADDR As String = String.Empty

    End Class

    ''' <summary>
    ''' 契約区分コード
    ''' </summary>
    Public Class KeiyakuKbnCd

        ''' <summary>
        ''' 契約区分コードFROM
        ''' </summary>
        Public Property VALUE_FM As Integer? = Nothing

        ''' <summary>
        ''' 契約区分コードTO
        ''' </summary>
        Public Property VALUE_TO As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 事務委託先番号コード
    ''' </summary>
    Public Class ItakuCd

        ''' <summary>
        ''' 事務委託先番号コードFROM
        ''' </summary>
        Public Property VALUE_FM As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先番号コードTO
        ''' </summary>
        Public Property VALUE_TO As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 契約者番号コード
    ''' </summary>
    Public Class KeiyakusyaCd

        ''' <summary>
        ''' 契約者番号コードFROM
        ''' </summary>
        Public Property VALUE_FM As Integer? = Nothing

        ''' <summary>
        ''' 契約者番号コードTO
        ''' </summary>
        Public Property VALUE_TO As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 契約状況
    ''' </summary>
    Public Class KeiyakuJyokyo
       ''' <summary>
        ''' 契約状況[新規契約者]
        ''' </summary>
        Public Property SHINKI As Boolean= True

        ''' <summary>
        ''' 契約状況[継続契約者]
        ''' </summary>
        Public Property KEIZOKU As Boolean= True

        ''' <summary>
        ''' 契約状況[中止契約者]
        ''' </summary>
        Public Property CHUSHI As Boolean= True

        ''' <summary>
        ''' 契約状況[廃業者]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        ''' </summary>
        Public Property HAIGYO As Boolean= True

    End Class

End Namespace
