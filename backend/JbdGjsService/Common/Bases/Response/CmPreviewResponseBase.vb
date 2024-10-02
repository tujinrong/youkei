' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: プレビュー処理
' 　　　　　　レスポンスインターフェースベース
' 作成日　　: 2024.07.21
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class CmPreviewResponseBase
        Inherits DaResponseBase
        Public Property filenm As String                                          'ファイル名

        <JsonIgnore>
        Public Property data As MemoryStream                                            'データ
        Public Property contenttype As String                                     'コンテンツタイプ

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New(recode As EnumServiceResult,msg As String)
            MyBase.New(recode, msg)
        End Sub

    End Class
End Namespace
