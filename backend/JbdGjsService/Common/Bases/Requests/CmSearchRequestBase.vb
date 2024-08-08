' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 検索処理
' 　　　　　　リクエストインターフェースベース
' 作成日　　: 2024.07.26
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmSearchRequestBase
        Inherits Db.DaRequestBase
        Public Property pagesize As Integer = 20             'ページサイズ
        Public Property pagenum As Integer = 1               'ページNo.
        Public Property orderby As Integer = 0               '並び順

        Public Overridable Property personalno As String     '個人番号
        Public Sub SetPersonalno()
            If Not String.IsNullOrEmpty(personalno) Then
                '復号化
                personalno = Db.JbdGjsEncryptUtil.RsaDecrypt(personalno)
            End If
        End Sub
    End Class
End Namespace
