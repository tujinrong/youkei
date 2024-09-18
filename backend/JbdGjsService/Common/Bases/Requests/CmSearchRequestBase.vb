' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 検索処理
' 　　　　　　リクエストインターフェースベース
' 作成日　　: 2024.07.26
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmSearchRequestBase
        Inherits DaRequestBase
        Public Property PAGE_SIZE As Integer = 20             'ページサイズ
        Public Property PAGE_NUM As Integer = 1               'ページNo.
        Public Property ORDER_BY As Integer = 0               '並び順

        Public Overridable Property personalno As String
        Public Sub SetPersonalno()
            If Not String.IsNullOrEmpty(personalno) Then
                '復号化
                personalno = CmEncryptUtil.RsaDecrypt(personalno)
            End If
        End Sub
    End Class
End Namespace
