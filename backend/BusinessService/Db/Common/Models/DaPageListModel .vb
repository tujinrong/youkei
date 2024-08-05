' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 改ページ画面のモデル定義
'
' 作成日　　: 2024.07.10
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class DaPageListModel
        Public TotalCount As Integer
        Public Property dataTable As Data.DataTable = New Data.DataTable()
    End Class
End Namespace
