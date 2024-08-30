' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: アップロード処理
' 　　　　　　リクエストインターフェースベース
' 作成日　　: 2024.07.21
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmUploadRequestBase
        Inherits DaRequestBase
        Public Property files As List(Of DaFileModel) = New List(Of DaFileModel)()     ' ファイルリスト
    End Class
End Namespace
