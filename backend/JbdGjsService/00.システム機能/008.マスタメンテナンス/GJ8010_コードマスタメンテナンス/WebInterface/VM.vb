' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
'            ビューモデル定義
' 作成日　　: 2024.09.13
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8010

    ''' <summary>
    ''' コード情報
    ''' </summary>
    Public Class SearchRowVM

        ''' <summary>
        ''' 名称コード
        ''' </summary>
        Public Property MEISYO_CD As Integer = Nothing

        ''' <summary>
        ''' 名称
        ''' </summary>
        Public Property MEISYO As String = String.Empty

        ''' <summary>
        ''' 略称
        ''' </summary>
        Public Property RYAKUSYO As String = String.Empty

    End Class
End Namespace
