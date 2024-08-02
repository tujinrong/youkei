' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 名称マスタ
'
' 作成日　　: 2024.07.10
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class DaNameModel
        Public Property nmcd As String = String.Empty   '名称コード
        Public Property nm As String = String.Empty     '名称
        Public Sub New(nmcd As String, nm As String)
            Me.nmcd = nmcd
            Me.nm = nm
        End Sub
    End Class
End Namespace
