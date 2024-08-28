' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者一覧表
'            ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

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
