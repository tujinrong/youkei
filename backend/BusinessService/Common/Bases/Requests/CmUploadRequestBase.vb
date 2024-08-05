' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: アップロード処理
' 　　　　　　リクエストインターフェースベース
' 作成日　　: 2024.07.14
' 作成者　　: 蔣
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmUploadRequestBase
        Inherits Db.DaRequestBase
        Public Property files As List(Of Db.DaFileModel) = New List(Of Db.DaFileModel)()     ' ファイルリスト
    End Class
End Namespace
